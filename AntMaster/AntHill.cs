using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace AntMaster
{
    delegate void PheromoneBlender(double better, double worse, ref double new_better, ref double new_worse);

    class AntHill : IComparable<AntHill>
    {
        public double[,] mPheromone; // aktualna tablica feromonow
        private PreviewImage mImage; // graficzny podlgad feromonow

        int       mAntsCount;  // liczba mrowek w mrowisku
        int       mIterations; // liczba iteracji dla mrowiska
        List<int> mBestPath;   // najlepsza znaleziona "sciezka"
        int       mBestCost;   // najlepszy koszt "sciezki" (im mniejszy => tym lepszy)
        Ant[]     ants;        // mrowki [agenci]
        double[,] pheromones;  // feromony w aktywnym przebiegu
        double    mEvaporate;  // wspolczynnik "parowania" feromonow

        SemaphoreSlim _sm; // semafora binarna kontrolujaca dostep do obrazka

        public AntHill() 
        {
            _sm = new SemaphoreSlim(1); // binarna semafora
        }

        public void LockImage() { _sm.Wait(); }
        public void UnlockImage() { _sm.Release(); }

        /// <summary>
        /// Funkcja porownujaca mrowiska do ustalnia rankingu najlepszych rozwiazan
        /// </summary>
        /// <param name="ah">inne mrowisko</param>
        /// <returns>-1 jest jest przed, 1 jesli po, 0 jak sa rowne</returns>
        public int CompareTo(AntHill ah)
        {
            return mBestCost.CompareTo(ah.BestCost);
        }

        #region gets and sets
        public TasksInfo Tasks { get; set; }
        public List<int> BestPath { get { return mBestPath; } }
        public int BestCost { get { return mBestCost; } }
        public Bitmap Pheromones { get { return mImage.Get; } }
        
        /// <summary>
        /// Ustawia wspolczynnik parownia feromonow
        /// </summary>
        public double Evaporation 
        { 
            get { return mEvaporate; }
            set { mEvaporate = 1.0 - mEvaporate; }
        }
        #endregion

        /// <summary>
        /// Inicjalizuje mrowisko odpowiednimi danymi
        /// </summary>
        /// <param name="tasks">zadania do uszeregowania</param>
        /// <param name="iterations">liczba wysylania mrowek do pracy</param>
        /// <param name="evaporation">wspolczynnik parowania</param>
        public void Init(TasksInfo tasks, int iterations = 1000, int antsCount = 5, double evaporation = 0.1)
        {
            Tasks = tasks;
            
            mAntsCount  = antsCount;
            mIterations = iterations;
            mEvaporate  = 1.0 - evaporation;

            mBestCost = int.MaxValue;
            mBestPath = new List<int>();

            ants = new Ant[mAntsCount];
            for (int i = 0; i < mAntsCount; ++i)
            {
                ants[i] = new Ant();
                ants[i].Home(this);
            }

            mPheromone = new double[tasks.Size, tasks.Size];
            pheromones = new double[tasks.Size, tasks.Size];

            for (int i = 0; i < tasks.Size; ++i)
            {
                for (int j = 0; j < tasks.Size; ++j)
                {
                    mPheromone[i,j]  = 0.002;
                    pheromones[i, j] = 0.0;
                }
            }

            _sm.Wait();
            mImage = new PreviewImage();
            mImage.Create(Tasks.Size);
            mImage.Visualise(mPheromone);
            _sm.Release();
        }

        /// <summary>
        /// Wysyla mrowki z mrowiska iles razy w poszukiwaniu optimum.
        /// Zapisywane jest najlepsze znalezione rozwiazanie do tej pory.
        /// </summary>
        public void AntAttack()
        {
            /// moze ta petla powinna byc poziom wyzej?
            /// albo zrobiona while (do) i w srodku while (!wait) do synchro mrowisk...
            for (int it = 0; it < mIterations; ++it)
            {
                ClearTempPheromones();
                SendAnts();
                UpdatePheromones();
            }
        }

        /// <summary>
        /// Wysyla wszystkie mrowki (niezaleznie) w poszukiwaniu rozwiazania
        /// modyfikujac tablice pheromones.
        /// </summary>
        private void SendAnts()
        {
            foreach (var ant in ants)
            {
                ant.Walk();

                /// zapisanie najlepszego rozwiazania w mrowisku
                if (ant.Cost < mBestCost) {
                    mBestCost = ant.Cost;
                    // kopiuj sciezke
                    mBestPath.Clear();
                    foreach (var task in ant.Path)
                        mBestPath.Add(task);
                }

                /// uaktualnienie feromonu w sciezce
                double pheromone = 1.0 / ant.Cost; // todo: czy moze byc dzielenie przez zero?
                ///TODO dodac jakas heurystyke
                for (int i = 0; i < Tasks.Size; ++i) {
                    pheromones[i, ant.Path[i]] += pheromone;
                }
            }
        }

        /// <summary>
        /// Uaktualnia globalnie feromony - odparowuje i laczy feromony
        /// wszystkich mrowek z danego przebiegu
        /// </summary>
        private void UpdatePheromones()
        {
            //for (int i = 0; i < Tasks.Size; ++i)
            System.Threading.Tasks.Parallel.For(0, Tasks.Size, (int i) =>
            {
                for (int j = 0; j < Tasks.Size; ++j)
                {
                    mPheromone[i, j] = mPheromone[i, j] * mEvaporate + pheromones[i, j];
                }
            }
            );

            _sm.Wait();
            mImage.Visualise(mPheromone);
            _sm.Release();
        }

        /// <summary>
        /// Czysci bufor na tymczasowe feromony (ze wszystkich mrowek z danego przebiegu)
        /// </summary>
        private void ClearTempPheromones()
        {
            for (int i = 0; i < Tasks.Size; ++i)
            {
                for (int j = 0; j < Tasks.Size; ++j)
                {
                    pheromones[i, j] = 0.0;
                }
            }
        }

        
        /// <summary>
        /// Dokonuje mieszania feromonow z dwoch mrowisk
        /// </summary>
        /// <param name="other">gorsze mrowisko</param>
        /// <param name="blender">funkcja mieszajaca</param>
        internal void BlendPheromones(ref AntHill other, PheromoneBlender blender)
        {
            AntHill local = other;

            System.Threading.Tasks.Parallel.For(0, Tasks.Size, (int i) =>
                {
                    double a = 0, b = 0;
                    for (int j = 0; j < Tasks.Size; ++j)
                    {
                        blender(mPheromone[i, j], local.mPheromone[i, j],ref a,ref b);
                        mPheromone[i, j] = a;
                        local.mPheromone[i, j] = b;
                    }
                });

            other = local;
        }
    }
}
