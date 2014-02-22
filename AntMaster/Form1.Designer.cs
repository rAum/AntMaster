namespace AntMaster
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbInfo = new System.Windows.Forms.RichTextBox();
            this.openFromFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pbPheromone = new System.Windows.Forms.PictureBox();
            this.nudAntHills = new System.Windows.Forms.NumericUpDown();
            this.bStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIteration = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudEvaporation = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAnts = new System.Windows.Forms.NumericUpDown();
            this.generateBtn = new System.Windows.Forms.Button();
            this.instanceCmbBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bgSolver = new System.ComponentModel.BackgroundWorker();
            this.tPictureUpdate = new System.Windows.Forms.Timer(this.components);
            this.heuristicCmbBox = new System.Windows.Forms.ComboBox();
            this.betaValueBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.aVal = new System.Windows.Forms.NumericUpDown();
            this.bVal = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cVal = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.dVal = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.alphaValueBox = new System.Windows.Forms.NumericUpDown();
            this.qValueBox = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPheromone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntHills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEvaporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qValueBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfo.CausesValidation = false;
            this.tbInfo.DetectUrls = false;
            this.tbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfo.Location = new System.Drawing.Point(3, 2);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(335, 501);
            this.tbInfo.TabIndex = 0;
            this.tbInfo.Text = "";
            // 
            // openFromFileBtn
            // 
            this.openFromFileBtn.Location = new System.Drawing.Point(397, 12);
            this.openFromFileBtn.Name = "openFromFileBtn";
            this.openFromFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFromFileBtn.TabIndex = 1;
            this.openFromFileBtn.Text = "Otwórz";
            this.openFromFileBtn.UseVisualStyleBackColor = true;
            this.openFromFileBtn.Click += new System.EventHandler(this.openFromFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text file|*.txt| All Files | *.*";
            // 
            // pbPheromone
            // 
            this.pbPheromone.BackColor = System.Drawing.Color.DimGray;
            this.pbPheromone.Location = new System.Drawing.Point(369, 193);
            this.pbPheromone.Name = "pbPheromone";
            this.pbPheromone.Size = new System.Drawing.Size(330, 310);
            this.pbPheromone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPheromone.TabIndex = 2;
            this.pbPheromone.TabStop = false;
            // 
            // nudAntHills
            // 
            this.nudAntHills.Location = new System.Drawing.Point(428, 79);
            this.nudAntHills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAntHills.Name = "nudAntHills";
            this.nudAntHills.Size = new System.Drawing.Size(78, 20);
            this.nudAntHills.TabIndex = 4;
            this.nudAntHills.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bStart
            // 
            this.bStart.Enabled = false;
            this.bStart.Location = new System.Drawing.Point(609, 12);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Liczba mrowisk:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Liczba iteracji:";
            // 
            // nudIteration
            // 
            this.nudIteration.Location = new System.Drawing.Point(428, 105);
            this.nudIteration.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIteration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIteration.Name = "nudIteration";
            this.nudIteration.Size = new System.Drawing.Size(78, 20);
            this.nudIteration.TabIndex = 8;
            this.nudIteration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Współ. parowania:";
            // 
            // nudEvaporation
            // 
            this.nudEvaporation.Location = new System.Drawing.Point(617, 104);
            this.nudEvaporation.Name = "nudEvaporation";
            this.nudEvaporation.Size = new System.Drawing.Size(91, 20);
            this.nudEvaporation.TabIndex = 10;
            this.nudEvaporation.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Liczba mrówek:";
            // 
            // nudAnts
            // 
            this.nudAnts.Location = new System.Drawing.Point(617, 78);
            this.nudAnts.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudAnts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnts.Name = "nudAnts";
            this.nudAnts.Size = new System.Drawing.Size(91, 20);
            this.nudAnts.TabIndex = 12;
            this.nudAnts.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(501, 12);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(75, 23);
            this.generateBtn.TabIndex = 14;
            this.generateBtn.Text = "Generuj";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generate_Click_1);
            // 
            // instanceCmbBox
            // 
            this.instanceCmbBox.FormattingEnabled = true;
            this.instanceCmbBox.Location = new System.Drawing.Point(543, 51);
            this.instanceCmbBox.Name = "instanceCmbBox";
            this.instanceCmbBox.Size = new System.Drawing.Size(100, 21);
            this.instanceCmbBox.TabIndex = 15;
            this.instanceCmbBox.SelectedValueChanged += new System.EventHandler(this.instanceChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Wybór instancji problemu:";
            // 
            // bgSolver
            // 
            this.bgSolver.WorkerReportsProgress = true;
            this.bgSolver.WorkerSupportsCancellation = true;
            this.bgSolver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSolver_DoWork);
            this.bgSolver.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgSolver_ProgressChanged);
            this.bgSolver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSolver_RunWorkerCompleted);
            // 
            // tPictureUpdate
            // 
            this.tPictureUpdate.Interval = 200;
            this.tPictureUpdate.Tick += new System.EventHandler(this.tPictureUpdate_Tick);
            // 
            // heuristicCmbBox
            // 
            this.heuristicCmbBox.FormattingEnabled = true;
            this.heuristicCmbBox.Location = new System.Drawing.Point(406, 136);
            this.heuristicCmbBox.Name = "heuristicCmbBox";
            this.heuristicCmbBox.Size = new System.Drawing.Size(66, 21);
            this.heuristicCmbBox.TabIndex = 17;
            this.heuristicCmbBox.SelectedValueChanged += new System.EventHandler(this.heuristicChanged);
            // 
            // betaValueBox
            // 
            this.betaValueBox.Location = new System.Drawing.Point(652, 137);
            this.betaValueBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.betaValueBox.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.betaValueBox.Name = "betaValueBox";
            this.betaValueBox.Size = new System.Drawing.Size(43, 20);
            this.betaValueBox.TabIndex = 18;
            this.betaValueBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Heurystyka:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(552, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "α:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(381, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "a =";
            // 
            // aVal
            // 
            this.aVal.Location = new System.Drawing.Point(409, 166);
            this.aVal.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.aVal.Name = "aVal";
            this.aVal.Size = new System.Drawing.Size(47, 20);
            this.aVal.TabIndex = 28;
            this.aVal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // bVal
            // 
            this.bVal.Location = new System.Drawing.Point(490, 166);
            this.bVal.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bVal.Name = "bVal";
            this.bVal.Size = new System.Drawing.Size(47, 20);
            this.bVal.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(462, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "b =";
            // 
            // cVal
            // 
            this.cVal.Location = new System.Drawing.Point(571, 166);
            this.cVal.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.cVal.Name = "cVal";
            this.cVal.Size = new System.Drawing.Size(47, 20);
            this.cVal.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(543, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "c =";
            // 
            // dVal
            // 
            this.dVal.Location = new System.Drawing.Point(652, 166);
            this.dVal.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.dVal.Name = "dVal";
            this.dVal.Size = new System.Drawing.Size(47, 20);
            this.dVal.TabIndex = 34;
            this.dVal.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(624, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "d =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "β:";
            // 
            // alphaValueBox
            // 
            this.alphaValueBox.Location = new System.Drawing.Point(575, 137);
            this.alphaValueBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.alphaValueBox.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.alphaValueBox.Name = "alphaValueBox";
            this.alphaValueBox.Size = new System.Drawing.Size(43, 20);
            this.alphaValueBox.TabIndex = 36;
            this.alphaValueBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // qValueBox
            // 
            this.qValueBox.Location = new System.Drawing.Point(503, 137);
            this.qValueBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.qValueBox.Name = "qValueBox";
            this.qValueBox.Size = new System.Drawing.Size(43, 20);
            this.qValueBox.TabIndex = 38;
            this.qValueBox.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(480, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "q:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 508);
            this.Controls.Add(this.qValueBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.alphaValueBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dVal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cVal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bVal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.aVal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.betaValueBox);
            this.Controls.Add(this.heuristicCmbBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.instanceCmbBox);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudAnts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudEvaporation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudIteration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.nudAntHills);
            this.Controls.Add(this.pbPheromone);
            this.Controls.Add(this.openFromFileBtn);
            this.Controls.Add(this.tbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "Jednomaszynowy problem szeregowania zadań - algorytm mrówkowy";
            ((System.ComponentModel.ISupportInitialize)(this.pbPheromone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntHills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEvaporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qValueBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbInfo;
        private System.Windows.Forms.Button openFromFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pbPheromone;
        private System.Windows.Forms.NumericUpDown nudAntHills;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudIteration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudEvaporation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudAnts;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.ComboBox instanceCmbBox;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker bgSolver;
        private System.Windows.Forms.Timer tPictureUpdate;
        private System.Windows.Forms.ComboBox heuristicCmbBox;
        private System.Windows.Forms.NumericUpDown betaValueBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown aVal;
        private System.Windows.Forms.NumericUpDown bVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown cVal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown dVal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown alphaValueBox;
        private System.Windows.Forms.NumericUpDown qValueBox;
        private System.Windows.Forms.Label label13;
    }
}

