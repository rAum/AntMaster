using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMaster
{
    class Ant
    {
        AntHill   mHome;         // mrowisko do ktrego mrowka nalezy
        List<int> mPath;         // przebyta sciezka     [wykonane zadania]
        List<int> freeTasks;     // gdzie mozna sie udac [niewykonane zadania]
        int       mCost;         // wazony koszt sciezki
        int       mTime;         // czas wykonania zadan
        int       mSize;         // liczba zadan do wykonania
        System.Security.Cryptography.RNGCryptoServiceProvider rnd; // generator liczb pseudolosowych
        TasksInfo mTasks;
        delegate int DChooseWay();
        delegate double DMiniHeura(int task);
        double k = 1.0;

        DChooseWay mChooseWay;
        DMiniHeura heura;

        public Ant() 
        {
            mSize = 0;
            mPath = new List<int>();
            freeTasks = new List<int>();
            rnd = new System.Security.Cryptography.RNGCryptoServiceProvider();
        }

        private double NextDouble()
        {
            byte[] res = new byte[8];
            rnd.GetBytes(res);
            return (double)BitConverter.ToUInt64(res, 0) / (double)UInt64.MaxValue;
        }

        private int NextInt(int max)
        {
            byte[] res = new byte[4];
            rnd.GetBytes(res);
            return Math.Abs(BitConverter.ToInt32(res,0)) % max;
        }

        public List<int> Path { get { return mPath; } }
        public int Cost { get { return mCost; } }
        public int Time { get { return mTime; } }
        /// <summary>
        /// Pozycja mrowki (ile zadan zostalo juz odwiedzonych)
        /// </summary>
        public int Position { get { return mSize - freeTasks.Count; } }

        /// <summary>
        /// Ustaw mrowisko do ktorego mrowka nalezy oraz ustawia odpowiednia heurystyke
        /// </summary>
        /// <param name="home">Mrowisko-matka :P</param>
        public void Home(AntHill home)
        {
            mHome = home;
            mSize = home.Tasks.Size;
            mTasks = home.Tasks;

            switch (mTasks.mHeuristic)
            {
                case "EDD":
                    mChooseWay = new DChooseWay(HeuristicWay);
                    heura = new DMiniHeura(heura_edd);
                    break;
                case "MDD":
                    mChooseWay = new DChooseWay(HeuristicWay);
                    heura = new DMiniHeura(heura_mdd);
                    break;
                case "AU":
                    mChooseWay = new DChooseWay(HeuristicWay_AU);
                    break;
                default:
                    mChooseWay = new DChooseWay(RandomWay);
                    break;
            }
        }

        /// <summary>
        /// Przejdz trase mrowka i wroc do mrowiska
        /// </summary>
        internal void Walk()
        {
            Spawn();

            mCost = mTime = 0;
            while (freeTasks.Count != 0) // dopoki sa jeszcze niewykonane zadania
            {
                int task = mChooseWay();
                mPath.Add(task);
                mTime += mTasks.mExecutionTime[task];
                mCost += mTasks.mWages[task] * Math.Max(0, mTime - mTasks.mDeadlines[task]);
            }
        }

        /// <summary>
        /// Swtorz mrowke, czyli ustaw odpowiednio ustawienia (zresetuj)
        /// </summary>
        private void Spawn()
        {
            mPath.Clear();

            freeTasks.Clear(); // niby powinno byc puste, ale na wszelki wypadek
            for (int i = 0; i < mSize; ++i) {
                freeTasks.Add(i);
            }
        }

        /// <summary>
        /// Wybiera kolejne zadanie i je usuwa ze sciezki
        /// </summary>
        /// <returns>nr wybranego zadania</returns>
        int RandomWay()
        {
            List<double> prob = computeProbability();
            double choose = NextDouble();

            int id = freeTasks[freeTasks.Count - 1]; // jesli ponizsza petla nie zadziala, to wybieramy ostatni :P
            for (int i = 0; i < freeTasks.Count; ++i)
            {
                if (choose < prob[i])
                {
                    id = freeTasks[i];
                    break;
                }
            }

            freeTasks.Remove(id); // usun zadanie z listy
            return id;
        }
  
        double heura_edd(int task)
        {
            return mTasks.mDeadlines[task];
        }

        double heura_mdd(int task)
        {
            return Math.Max(mTasks.mDeadlines[task], mTime + mTasks.mDeadlines[task]);
        }

        /// <summary>
        /// Najbardziej wymyslna heurystyka - okreslonej waznosci (AU) 
        /// </summary>
        /// <returns>kolejne zadanie do wykonania</returns>
        int HeuristicWay_AU()
        {
            int id;
            if (NextDouble() > mTasks.mQ) // z prawdopodobienstwem 1 - q wybieramy losowa droge
            {
                id = freeTasks[NextInt(freeTasks.Count)];
                freeTasks.Remove(id);
                return id;
            }

            int i = Position;

            int sum = 0;
            foreach (int task in freeTasks)
            {
                sum += mTasks.mExecutionTime[task];
            }
            double p_average = (double)sum / freeTasks.Count;

            List<double> costs = new List<double>(freeTasks.Count);
            double cost;
            foreach (int task in freeTasks)
            {
                double wj = mTasks.mWages[task];
                double pj = mTasks.mExecutionTime[task];
                double dj = mTasks.mDeadlines[task];

                double to_exp = -Math.Max(0.0, dj - (mTime + pj)) / (k * p_average);
                cost = Math.Pow((wj / pj) * Math.Exp(to_exp), mTasks.mHeuristicBeta);
                costs.Add(Math.Pow(mHome.mPheromone[i, task], mTasks.mHeuristicAlpha) * Math.Pow(cost, mTasks.mHeuristicBeta));
            }

            cost = costs[0];
            id = freeTasks[0];
            for (int j = 1; j < freeTasks.Count; ++j)
            {
                if (cost < costs[j])
                {
                    cost = costs[j];
                    id = freeTasks[j];
                }
            }

            freeTasks.Remove(id);
            return id;
        }

        /// <summary>
        /// Heurystyka - Najwczesniejszy termin zakonczenia (EDD) albo modyfikowany
        /// termin zakonczenia zadania (MDD)
        /// </summary>
        /// <returns></returns>
        int HeuristicWay()
        {
            int id;
            if (NextDouble() > mTasks.mQ) // z prawdopodobienstwem 1 - q wybieramy losowa droge
            {
                id = freeTasks[NextInt(freeTasks.Count)];
                freeTasks.Remove(id);
                return id;
            }

            int i = Position;
            List<double> costs = new List<double>(freeTasks.Count);

            double cost = 0.0;
            foreach (int task in freeTasks)
            {
                costs.Add(Math.Pow(mHome.mPheromone[i, task], mTasks.mHeuristicAlpha) * Math.Pow(1.0 / heura(task), mTasks.mHeuristicBeta));
            }

            /// znajdz maksimum
            cost = costs[0];
            id = freeTasks[0];
            for (int j = 1; j < freeTasks.Count; ++j)
            {
                if (cost < costs[j])
                {
                    id = freeTasks[j];
                    cost = costs[j];
                }
            }

            freeTasks.Remove(id);
            return id;
        }

        /// <summary>
        /// Oblicza prawdopodobienstwo wybrania danej sciezki tworzac dystrybuante
        /// </summary>
        /// <returns>dystrybuanta dla prawdopodobienstwa wyboru sciezki</returns>
        private List<double> computeProbability()
        {
            List<double> prob = new List<double>(freeTasks.Count);     // dystrybuanta
            int i = Position;

            double sum = 0.0;
            foreach (int task in freeTasks)
            {
                sum += mHome.mPheromone[i, task];
            }

            double p = 0.0;
            foreach (var t in freeTasks) 
            {
                p += mHome.mPheromone[i, t] / sum; // prawdopodobienstwo wyboru zadania t
                prob.Add(p);
            }

            return prob;
        }
    }
}
