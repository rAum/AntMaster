using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AntMaster
{
    public partial class MainWindow : Form
    {
        TasksInfo mTasks;
        AntSolver mSolver;
        int mAntsCount, mAntHillsCount, mIterations;
        double mEvaporation;
        Stopwatch mTimer;

        public MainWindow()
        {
            InitializeComponent();
            mTasks    = null;
            heuristicCmbBox.Items.Add("ID");
            heuristicCmbBox.Items.Add("EDD");
            heuristicCmbBox.Items.Add("MDD");
            heuristicCmbBox.Items.Add("AU");
            heuristicCmbBox.SelectedItem = "ID";
            mTimer = new Stopwatch();
        }

        public delegate void UpdatePheromonesPreview(int num);

        private void button2_Click(object sender, EventArgs e)
        {
            if (bStart.Text == "Start")
            {
                mAntsCount = (int)nudAnts.Value;
                mAntHillsCount = (int)nudAntHills.Value;
                mIterations = (int)nudIteration.Value;
                mEvaporation = (double)nudEvaporation.Value / 100.0;
                mTasks.mHeuristicBeta = (double)betaValueBox.Value;
                mTasks.setBlendingParams((double)aVal.Value / 10.0, (double)bVal.Value / 10.0, (double)cVal.Value / 10.0, (double)dVal.Value / 10.0);
                mTasks.mHeuristicAlpha = (double)alphaValueBox.Value;
                mTasks.mQ = (double)qValueBox.Value / (double)qValueBox.Maximum;

                tbInfo.AppendText("Obliczenia rozpoczęte!\n");
                printExecutionParameters();
                mTimer.Reset();
                mTimer.Start();
                
                bgSolver.RunWorkerAsync();

                bStart.Text = "Stop";
                tPictureUpdate.Enabled = true;
            }
            else
            {
                tPictureUpdate.Enabled = false;
                bgSolver.CancelAsync();
                tbInfo.AppendText("Wymuszono koniec...proszę czekać...\n");
                mTimer.Stop();
                bStart.Enabled = false;
            }
        }

        private void openFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // wczytaj dane
                mTasks = new TasksInfo();
                mTasks.LoadFromFile(openFileDialog.FileName);
                mTasks.setCurrentInstance(0);
                for (int i = 0; i < mTasks.InstanceCount; ++i)
                {
                    instanceCmbBox.Items.Add(i);
                }
                instanceCmbBox.SelectedItem = 0;

                bStart.Enabled = true;
            }
        }

        private void generate_Click_1(object sender, EventArgs e)
        {
            // wygeneruj losowo dane
            mTasks = new TasksInfo();

            Random rnd = new Random();

            for (int i = 0; i < 10; ++i)
            {
                mTasks.mDeadlines.Add(rnd.Next(10, 100));
                mTasks.mExecutionTime.Add(rnd.Next(5, 25));
                mTasks.mWages.Add(rnd.Next(1, 2));
            }
            mTasks.Size = 10;

            bStart.Enabled = true;
            tbInfo.AppendText("Dane: losowe " + "\n", Color.SeaGreen);
        }

        private void instanceChanged(object sender, EventArgs e)
        {
            Int32 toDo = Convert.ToInt32(instanceCmbBox.SelectedItem.ToString());
            mTasks.setCurrentInstance(toDo);
            bStart.Enabled = true;
            tbInfo.AppendText("Dane: zestaw nr " + toDo + " z pliku.\n", Color.SeaGreen);
        }

        private void bgSolver_DoWork(object sender, DoWorkEventArgs e)
        {
            mSolver = new AntSolver();
            mSolver.Setup(mTasks, mAntHillsCount, mIterations, mAntsCount, mEvaporation, bgSolver );

            mSolver.Run();
        }

        private void bgSolver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tPictureUpdate.Enabled = false;
            pbPheromone.Image = mSolver.Pheromones;
            mTimer.Stop();

            tbInfo.AppendText("\nObliczenia zakończone!\n", Color.Red);
            tbInfo.AppendText("Czas wykonania: " + (mTimer.ElapsedMilliseconds / 1000.0).ToString() + " sekund.\n");
            tbInfo.AppendText("Koszt: "); tbInfo.AppendText(mSolver.Cost.ToString(), Color.Blue);
            tbInfo.AppendText("\nPermutacja: ");
            tbInfo.AppendText(String.Join(", ", mSolver.Path.ToArray()), Color.Green);
            tbInfo.AppendText("\n___________________________________\n", Color.Gray);
            tbInfo.SelectionStart = tbInfo.TextLength;
            tbInfo.ScrollToCaret();
            tbInfo.Update();

            bStart.Text = "Start";
            bStart.Enabled = true;
        }

        private void bgSolver_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (e.ProgressPercentage == 1)
            //{
                tbInfo.AppendText("obecny koszt: " + mSolver.Cost.ToString() + "\n");
                tbInfo.SelectionStart = tbInfo.TextLength;
                tbInfo.ScrollToCaret(); 
            //}
            //else if (e.ProgressPercentage == 0)
            //{
                //tbInfo.AppendText("mieszanie feromonow..\n", Color.Gray);
            //}
        }

        private void tPictureUpdate_Tick(object sender, EventArgs e)
        {
            pbPheromone.Image = (Image)mSolver.Pheromones.Clone();
            mSolver.UnlockPheromonesImage();
        }

        private void heuristicChanged(object sender, EventArgs e)
        {
            if(mTasks != null)
                mTasks.mHeuristic = heuristicCmbBox.SelectedItem.ToString();
        }

        private void printExecutionParameters()
        {
            tbInfo.AppendText("\nl.mrowisk = " + mAntHillsCount.ToString() + "\t l.mrówek = " + mAntsCount + "\n", Color.PaleVioletRed);
            tbInfo.AppendText("l.iteracji = " + mIterations.ToString() + "\t współ.parowania = " + mEvaporation + "\n", Color.PaleVioletRed);
            tbInfo.AppendText("heurystyka = " + mTasks.mHeuristic + "\t q = " + mTasks.mQ + " α = " + mTasks.mHeuristicAlpha + " β = " + mTasks.mHeuristicBeta + "\n", Color.PaleVioletRed);
            tbInfo.AppendText("współ. mieszania feronomonów: a = " + mTasks.mBlendParameters[0] + " b = " + mTasks.mBlendParameters[1] + " c = " + mTasks.mBlendParameters[2] + " d = " + mTasks.mBlendParameters[3] + "\n", Color.PaleVioletRed);
            tbInfo.AppendText("\n");
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool bullet = false)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.SelectionBullet = bullet;
            box.ScrollToCaret();
        }
    }
}
