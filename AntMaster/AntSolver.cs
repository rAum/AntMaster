using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace AntMaster
{
    class AntSolver
    {
        AntHill[] mHills;  // mrowiska
        int mHillsCount;   // liczba mrowisk
        bool mDoWork;      // czy mrowiska maja pracowac ;)
        
        int mBestCost;
        List<int> mBestPath;

        int mIter;
        int mAnts;
        double mEvap;
        TasksInfo mTasks;

        BackgroundWorker mBG;

        /// <summary>
        /// Umozliwia zatrzymanie pracy
        /// </summary>
        public bool Working { get { return mDoWork; } set { mDoWork = value; } }
        public int Cost { get { return mBestCost; } }
        public List<int> Path { get { return mBestPath; } }

        public void UnlockPheromonesImage()
        {
            mHills[0].UnlockImage();
        }

        public Image Pheromones 
        { 
            get 
            {
                mHills[0].LockImage();
                return mHills[0].Pheromones; 
            } 
        }

        /// <summary>
        /// Ustawia odpowiednie parametry
        /// </summary>
        /// <param name="tasks">Zadanie do rozwiazania</param>
        /// <param name="anthillsCount">liczba mrowisk</param>
        /// <param name="iter">liczba przebiegow w mrowisku zanim dojdzie do wymieszania feromonow</param>
        /// <param name="ants">liczba niezaleznych mrowek w mrowisku</param>
        /// <param name="evaporation">wspolczynnik parowania</param>
        public void Setup(TasksInfo tasks, int anthillsCount, int iter, int ants, double evaporation, BackgroundWorker bg)
        {
            mIter = iter;
            mAnts = ants;
            mEvap = evaporation;
            mTasks = tasks;
            mHillsCount = anthillsCount;
            mBG = bg;

            mHills = new AntHill[mHillsCount];
            mBestPath = new List<int>();

            Restart();
        }

        /// <summary>
        /// Reinicjalizuje ustawienia mrowisk
        /// </summary>
        private void Restart()
        {
            mDoWork   = false;
            mBestCost = int.MaxValue;

            for (int i = 0; i < mHillsCount; ++i)
            {
                mHills[i] = new AntHill();
                mHills[i].Init(mTasks, mIter, mAnts, mEvap);
            }
        }

        private void blendLinear(double better, double worse, ref double new_better, ref double new_worse)
        {
            new_better = mTasks.mBlendParameters[0] * better + mTasks.mBlendParameters[1] * worse;
            new_worse  = mTasks.mBlendParameters[2] * better + mTasks.mBlendParameters[3] * worse;
        }

        /// <summary>
        /// Odpala rozwiazywanie problemu.
        /// </summary>
        public void Run()
        {
            PheromoneBlender blender = new PheromoneBlender(blendLinear);

            while (mBG.CancellationPending == false)
            {
                System.Threading.Tasks.Parallel.For(0, mHillsCount, (int i) =>
                {
                    mHills[i].AntAttack();
                });

                AntHill tmp = mHills[0];
                tmp.LockImage();
                /// rank & wymiana feromonow
                Array.Sort(mHills); // sortowanie po najlepszej sciezce
                tmp.UnlockImage();

                if (mHills[0].BestCost < mBestCost)
                {
                    mBestCost = mHills[0].BestCost;
                    mBestPath.Clear();
                    foreach (int task in mHills[0].BestPath)
                        mBestPath.Add(task);

                    mBG.ReportProgress(1);
                }

                //mBG.ReportProgress(0);
                tmp.LockImage();
                for (int i = 0; i < mHillsCount / 2; ++i) // zmieszanie feromonow
                    mHills[i].BlendPheromones(ref mHills[mHillsCount - i - 1], blender);
                tmp.UnlockImage();
            }
        }
    }
}
