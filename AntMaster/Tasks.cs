using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace AntMaster
{
    class TasksInfo
    {
        public class InstanceInfo
        {
            public List<int> _Deadlines;     // d_i - terminy wykonania zadania
            public List<int> _Wages;         // w_i - waga zadania
            public List<int> _ExecutionTime; // p_i - czas wykonania zadania

            public InstanceInfo()
            {
                _Deadlines = new List<int>();
                _Wages = new List<int>();
                _ExecutionTime = new List<int>();
            }
        };

        public List<int> mDeadlines;     // d_i - terminy wykonania zadania
        public List<int> mWages;         // w_i - waga zadania
        public List<int> mExecutionTime; // p_i - czas wykonania zadania

        public List<InstanceInfo> mInstances;
        public int mCurrInstance;
        public string mHeuristic;
        public Double mHeuristicBeta;
        public double mHeuristicAlpha;
        public double[] mBlendParameters;
        public double mQ; // dla heurystyk

        int mSize;

        public TasksInfo() 
        {
            mWages = new List<int>();
            mDeadlines = new List<int>();
            mExecutionTime = new List<int>();
            lazyBias   = ComputeTotalExecTime;
            mInstances = new List<InstanceInfo>();
            mCurrInstance = -1;
            mBias = 0;
            mSize = 0;
            mHeuristic = "ID";
            mHeuristicBeta = 1.0;
            mHeuristicAlpha = 1.0;
            mBlendParameters = new double[4] {1.0, 1.0, 1.0, 1.0};
            mQ = 0.3;
        }
        
        /// <summary>
        /// Liczba zadan do wykonania
        /// </summary>
        public int Size { get { return mSize; } set { mSize = value; } }
        /// <summary>
        /// Minimalny czas na wykonanie wszystkich zadan [suma czasow wykonania kazdego zadania]
        /// </summary>
        public int Bias { get { return lazyBias(); } }

        public int InstanceCount { get { return mInstances.Count; } }

        #region private - trick z leniwym obliczeniem Bias
        int mBias;
        delegate int LazyGet();
        LazyGet lazyBias;

        int ComputeTotalExecTime()
        {
            mBias = mExecutionTime.Sum();
            lazyBias = GetTotalExecTime;
            return mBias;
        }

        int GetTotalExecTime()
        {
            return mBias;
        }
        #endregion

        public void LoadFromFile(string filename)
        {
            StreamReader streamRead = new StreamReader(filename);
            string[] digits = Regex.Split(streamRead.ReadToEnd(), @"\D+");

            mSize = Convert.ToInt32(digits[0]);
            int instanceId = 0;
            InstanceInfo currInstance = null;

            int pos = 1;
            while (pos < (digits.Length-1))
            {
                currInstance = new InstanceInfo();

                for (int i = 0; i < mSize; ++i)
                    currInstance._ExecutionTime.Add(Convert.ToInt32(digits[pos++]));
                for (int i = 0; i < mSize; ++i)
                    currInstance._Wages.Add(Convert.ToInt32(digits[pos++]));
                for (int i = 0; i < mSize; ++i)
                    currInstance._Deadlines.Add(Convert.ToInt32(digits[pos++]));

                mInstances.Add(currInstance);
                ++instanceId;
            }
        }

        public void setCurrentInstance(int _instance)
        {
            if (_instance != mCurrInstance)
            {
                mExecutionTime = mInstances[_instance]._ExecutionTime;
                mWages = mInstances[_instance]._Wages;
                mDeadlines = mInstances[_instance]._Deadlines;

                ComputeTotalExecTime();

                mCurrInstance = _instance;
            }
        }

        public void setBlendingParams(double a, double b, double c, double d)
        {
            mBlendParameters[0] = a;
            mBlendParameters[1] = b;
            mBlendParameters[2] = c;
            mBlendParameters[3] = d;
        }
    }
}
