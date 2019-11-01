namespace SoccerApplicationForMen
{
    partial class FixtureControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTeamStats = new System.Windows.Forms.Panel();
            this.lblCustomStats = new System.Windows.Forms.Label();
            this.cmbCustomStats = new System.Windows.Forms.ComboBox();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tblTeamStats = new System.Windows.Forms.TableLayoutPanel();
            this.cmbGD = new System.Windows.Forms.ComboBox();
            this.cmbDraws = new System.Windows.Forms.ComboBox();
            this.cmbLosses = new System.Windows.Forms.ComboBox();
            this.cmbWins = new System.Windows.Forms.ComboBox();
            this.lblPlayed = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.lblDraws = new System.Windows.Forms.Label();
            this.lblGoalDiff = new System.Windows.Forms.Label();
            this.numPlayed = new System.Windows.Forms.NumericUpDown();
            this.numWins = new System.Windows.Forms.NumericUpDown();
            this.numLosses = new System.Windows.Forms.NumericUpDown();
            this.numDraws = new System.Windows.Forms.NumericUpDown();
            this.numGD = new System.Windows.Forms.NumericUpDown();
            this.cmbPlayed = new System.Windows.Forms.ComboBox();
            this.lblTeamStats = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.numGamesToCount = new System.Windows.Forms.NumericUpDown();
            this.lblGamesToCount = new System.Windows.Forms.Label();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chkConsistancy = new System.Windows.Forms.CheckedListBox();
            this.pnlAverageWinLose = new System.Windows.Forms.Panel();
            this.rdbOFF = new System.Windows.Forms.RadioButton();
            this.rdbON = new System.Windows.Forms.RadioButton();
            this.numAveWinLose = new System.Windows.Forms.NumericUpDown();
            this.lblAveWinLose = new System.Windows.Forms.Label();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnRollFixture = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.rdbResults = new System.Windows.Forms.RadioButton();
            this.rdbFixtures = new System.Windows.Forms.RadioButton();
            this.pnlFixAndResults = new System.Windows.Forms.Panel();
            this.pnlFixture = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTeamStats.SuspendLayout();
            this.tblTeamStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLosses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDraws)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGD)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGamesToCount)).BeginInit();
            this.panel6.SuspendLayout();
            this.pnlAverageWinLose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAveWinLose)).BeginInit();
            this.pnlFixAndResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.btnResults);
            this.panel4.Controls.Add(this.btnRollFixture);
            this.panel4.Controls.Add(this.btnApply);
            this.panel4.Font = new System.Drawing.Font("Segoe UI Black", 8.25F);
            this.panel4.Location = new System.Drawing.Point(471, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 488);
            this.panel4.TabIndex = 21;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pnlTeamStats);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.dtpFilterDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.pnlAverageWinLose);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 424);
            this.panel1.TabIndex = 25;
            // 
            // pnlTeamStats
            // 
            this.pnlTeamStats.AutoScroll = true;
            this.pnlTeamStats.BackColor = System.Drawing.Color.Silver;
            this.pnlTeamStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlTeamStats.Controls.Add(this.lblCustomStats);
            this.pnlTeamStats.Controls.Add(this.cmbCustomStats);
            this.pnlTeamStats.Controls.Add(this.txtSave);
            this.pnlTeamStats.Controls.Add(this.btnSave);
            this.pnlTeamStats.Controls.Add(this.tblTeamStats);
            this.pnlTeamStats.Controls.Add(this.lblTeamStats);
            this.pnlTeamStats.Location = new System.Drawing.Point(29, 411);
            this.pnlTeamStats.Name = "pnlTeamStats";
            this.pnlTeamStats.Size = new System.Drawing.Size(252, 230);
            this.pnlTeamStats.TabIndex = 33;
            // 
            // lblCustomStats
            // 
            this.lblCustomStats.AutoSize = true;
            this.lblCustomStats.Location = new System.Drawing.Point(17, 174);
            this.lblCustomStats.Name = "lblCustomStats";
            this.lblCustomStats.Size = new System.Drawing.Size(78, 13);
            this.lblCustomStats.TabIndex = 5;
            this.lblCustomStats.Text = "Custom Stats";
            // 
            // cmbCustomStats
            // 
            this.cmbCustomStats.FormattingEnabled = true;
            this.cmbCustomStats.Location = new System.Drawing.Point(114, 171);
            this.cmbCustomStats.Name = "cmbCustomStats";
            this.cmbCustomStats.Size = new System.Drawing.Size(127, 21);
            this.cmbCustomStats.TabIndex = 4;
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(19, 203);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(127, 22);
            this.txtSave.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tblTeamStats
            // 
            this.tblTeamStats.BackColor = System.Drawing.Color.Ivory;
            this.tblTeamStats.ColumnCount = 3;
            this.tblTeamStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.66187F));
            this.tblTeamStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.33813F));
            this.tblTeamStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tblTeamStats.Controls.Add(this.cmbGD, 2, 4);
            this.tblTeamStats.Controls.Add(this.cmbDraws, 2, 3);
            this.tblTeamStats.Controls.Add(this.cmbLosses, 2, 2);
            this.tblTeamStats.Controls.Add(this.cmbWins, 2, 1);
            this.tblTeamStats.Controls.Add(this.lblPlayed, 0, 0);
            this.tblTeamStats.Controls.Add(this.lblWins, 0, 1);
            this.tblTeamStats.Controls.Add(this.lblLosses, 0, 2);
            this.tblTeamStats.Controls.Add(this.lblDraws, 0, 3);
            this.tblTeamStats.Controls.Add(this.lblGoalDiff, 0, 4);
            this.tblTeamStats.Controls.Add(this.numPlayed, 1, 0);
            this.tblTeamStats.Controls.Add(this.numWins, 1, 1);
            this.tblTeamStats.Controls.Add(this.numLosses, 1, 2);
            this.tblTeamStats.Controls.Add(this.numDraws, 1, 3);
            this.tblTeamStats.Controls.Add(this.numGD, 1, 4);
            this.tblTeamStats.Controls.Add(this.cmbPlayed, 2, 0);
            this.tblTeamStats.Location = new System.Drawing.Point(19, 25);
            this.tblTeamStats.Name = "tblTeamStats";
            this.tblTeamStats.RowCount = 5;
            this.tblTeamStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.00108F));
            this.tblTeamStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9237F));
            this.tblTeamStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9237F));
            this.tblTeamStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.07576F));
            this.tblTeamStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.07576F));
            this.tblTeamStats.Size = new System.Drawing.Size(222, 140);
            this.tblTeamStats.TabIndex = 1;
            // 
            // cmbGD
            // 
            this.cmbGD.FormattingEnabled = true;
            this.cmbGD.Location = new System.Drawing.Point(133, 113);
            this.cmbGD.Name = "cmbGD";
            this.cmbGD.Size = new System.Drawing.Size(78, 21);
            this.cmbGD.TabIndex = 14;
            // 
            // cmbDraws
            // 
            this.cmbDraws.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmbDraws.FormattingEnabled = true;
            this.cmbDraws.Location = new System.Drawing.Point(133, 85);
            this.cmbDraws.Name = "cmbDraws";
            this.cmbDraws.Size = new System.Drawing.Size(78, 21);
            this.cmbDraws.TabIndex = 13;
            // 
            // cmbLosses
            // 
            this.cmbLosses.FormattingEnabled = true;
            this.cmbLosses.Location = new System.Drawing.Point(133, 58);
            this.cmbLosses.Name = "cmbLosses";
            this.cmbLosses.Size = new System.Drawing.Size(78, 21);
            this.cmbLosses.TabIndex = 12;
            // 
            // cmbWins
            // 
            this.cmbWins.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmbWins.FormattingEnabled = true;
            this.cmbWins.Location = new System.Drawing.Point(133, 31);
            this.cmbWins.Name = "cmbWins";
            this.cmbWins.Size = new System.Drawing.Size(78, 21);
            this.cmbWins.TabIndex = 11;
            // 
            // lblPlayed
            // 
            this.lblPlayed.AutoSize = true;
            this.lblPlayed.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblPlayed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlayed.Location = new System.Drawing.Point(3, 0);
            this.lblPlayed.Name = "lblPlayed";
            this.lblPlayed.Size = new System.Drawing.Size(42, 13);
            this.lblPlayed.TabIndex = 0;
            this.lblPlayed.Text = "Played";
            // 
            // lblWins
            // 
            this.lblWins.AutoSize = true;
            this.lblWins.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblWins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWins.Location = new System.Drawing.Point(3, 28);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(34, 13);
            this.lblWins.TabIndex = 1;
            this.lblWins.Text = "Wins";
            // 
            // lblLosses
            // 
            this.lblLosses.AutoSize = true;
            this.lblLosses.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblLosses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLosses.Location = new System.Drawing.Point(3, 55);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(41, 13);
            this.lblLosses.TabIndex = 2;
            this.lblLosses.Text = "Losses";
            // 
            // lblDraws
            // 
            this.lblDraws.AutoSize = true;
            this.lblDraws.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDraws.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDraws.Location = new System.Drawing.Point(3, 82);
            this.lblDraws.Name = "lblDraws";
            this.lblDraws.Size = new System.Drawing.Size(40, 13);
            this.lblDraws.TabIndex = 3;
            this.lblDraws.Text = "Draws";
            // 
            // lblGoalDiff
            // 
            this.lblGoalDiff.AutoSize = true;
            this.lblGoalDiff.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblGoalDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGoalDiff.Location = new System.Drawing.Point(3, 110);
            this.lblGoalDiff.Name = "lblGoalDiff";
            this.lblGoalDiff.Size = new System.Drawing.Size(63, 26);
            this.lblGoalDiff.TabIndex = 4;
            this.lblGoalDiff.Text = "Goal Difference";
            // 
            // numPlayed
            // 
            this.numPlayed.Location = new System.Drawing.Point(98, 3);
            this.numPlayed.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numPlayed.Name = "numPlayed";
            this.numPlayed.Size = new System.Drawing.Size(29, 22);
            this.numPlayed.TabIndex = 5;
            // 
            // numWins
            // 
            this.numWins.BackColor = System.Drawing.SystemColors.Window;
            this.numWins.Location = new System.Drawing.Point(98, 31);
            this.numWins.Name = "numWins";
            this.numWins.Size = new System.Drawing.Size(29, 22);
            this.numWins.TabIndex = 6;
            // 
            // numLosses
            // 
            this.numLosses.Location = new System.Drawing.Point(98, 58);
            this.numLosses.Name = "numLosses";
            this.numLosses.Size = new System.Drawing.Size(29, 22);
            this.numLosses.TabIndex = 7;
            // 
            // numDraws
            // 
            this.numDraws.BackColor = System.Drawing.SystemColors.Window;
            this.numDraws.Location = new System.Drawing.Point(98, 85);
            this.numDraws.Name = "numDraws";
            this.numDraws.Size = new System.Drawing.Size(29, 22);
            this.numDraws.TabIndex = 8;
            // 
            // numGD
            // 
            this.numGD.Location = new System.Drawing.Point(98, 113);
            this.numGD.Name = "numGD";
            this.numGD.Size = new System.Drawing.Size(29, 22);
            this.numGD.TabIndex = 9;
            // 
            // cmbPlayed
            // 
            this.cmbPlayed.FormattingEnabled = true;
            this.cmbPlayed.Location = new System.Drawing.Point(133, 3);
            this.cmbPlayed.Name = "cmbPlayed";
            this.cmbPlayed.Size = new System.Drawing.Size(78, 21);
            this.cmbPlayed.TabIndex = 10;
            // 
            // lblTeamStats
            // 
            this.lblTeamStats.AutoSize = true;
            this.lblTeamStats.Location = new System.Drawing.Point(85, 9);
            this.lblTeamStats.Name = "lblTeamStats";
            this.lblTeamStats.Size = new System.Drawing.Size(87, 13);
            this.lblTeamStats.TabIndex = 0;
            this.lblTeamStats.Text = "Team Statistics";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.numGamesToCount);
            this.panel5.Controls.Add(this.lblGamesToCount);
            this.panel5.Location = new System.Drawing.Point(29, 52);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(252, 37);
            this.panel5.TabIndex = 30;
            // 
            // numGamesToCount
            // 
            this.numGamesToCount.Location = new System.Drawing.Point(130, 4);
            this.numGamesToCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numGamesToCount.Name = "numGamesToCount";
            this.numGamesToCount.Size = new System.Drawing.Size(42, 22);
            this.numGamesToCount.TabIndex = 1;
            this.numGamesToCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblGamesToCount
            // 
            this.lblGamesToCount.AutoSize = true;
            this.lblGamesToCount.Location = new System.Drawing.Point(16, 6);
            this.lblGamesToCount.Name = "lblGamesToCount";
            this.lblGamesToCount.Size = new System.Drawing.Size(91, 13);
            this.lblGamesToCount.TabIndex = 0;
            this.lblGamesToCount.Text = "Games to count";
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.CalendarMonthBackground = System.Drawing.Color.Ivory;
            this.dtpFilterDate.Location = new System.Drawing.Point(73, 20);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(208, 22);
            this.dtpFilterDate.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Date";
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.chkConsistancy);
            this.panel6.Location = new System.Drawing.Point(29, 95);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(252, 236);
            this.panel6.TabIndex = 32;
            // 
            // chkConsistancy
            // 
            this.chkConsistancy.BackColor = System.Drawing.Color.Ivory;
            this.chkConsistancy.FormattingEnabled = true;
            this.chkConsistancy.Items.AddRange(new object[] {
            "Select All",
            "Home Winner",
            "Away Winner",
            "On-Form Winner",
            "On-Form Loser",
            "On-Form Scorer",
            "Home Loser",
            "Away Loser",
            "Regular Drawer",
            "Home Drawer",
            "Away Drawer",
            "Clean Sheeter"});
            this.chkConsistancy.Location = new System.Drawing.Point(67, 14);
            this.chkConsistancy.Name = "chkConsistancy";
            this.chkConsistancy.Size = new System.Drawing.Size(126, 208);
            this.chkConsistancy.TabIndex = 1;
            // 
            // pnlAverageWinLose
            // 
            this.pnlAverageWinLose.BackColor = System.Drawing.Color.Silver;
            this.pnlAverageWinLose.Controls.Add(this.rdbOFF);
            this.pnlAverageWinLose.Controls.Add(this.rdbON);
            this.pnlAverageWinLose.Controls.Add(this.numAveWinLose);
            this.pnlAverageWinLose.Controls.Add(this.lblAveWinLose);
            this.pnlAverageWinLose.Location = new System.Drawing.Point(29, 337);
            this.pnlAverageWinLose.Name = "pnlAverageWinLose";
            this.pnlAverageWinLose.Size = new System.Drawing.Size(252, 68);
            this.pnlAverageWinLose.TabIndex = 31;
            // 
            // rdbOFF
            // 
            this.rdbOFF.AutoSize = true;
            this.rdbOFF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdbOFF.Checked = true;
            this.rdbOFF.Location = new System.Drawing.Point(67, 9);
            this.rdbOFF.Name = "rdbOFF";
            this.rdbOFF.Size = new System.Drawing.Size(45, 17);
            this.rdbOFF.TabIndex = 3;
            this.rdbOFF.TabStop = true;
            this.rdbOFF.Text = "OFF";
            this.rdbOFF.UseVisualStyleBackColor = true;
            this.rdbOFF.CheckedChanged += new System.EventHandler(this.rdbOFF_CheckedChanged_1);
            // 
            // rdbON
            // 
            this.rdbON.AutoSize = true;
            this.rdbON.Location = new System.Drawing.Point(19, 9);
            this.rdbON.Name = "rdbON";
            this.rdbON.Size = new System.Drawing.Size(42, 17);
            this.rdbON.TabIndex = 2;
            this.rdbON.Text = "ON";
            this.rdbON.UseVisualStyleBackColor = true;
            this.rdbON.CheckedChanged += new System.EventHandler(this.rdbON_CheckedChanged_2);
            // 
            // numAveWinLose
            // 
            this.numAveWinLose.Enabled = false;
            this.numAveWinLose.Location = new System.Drawing.Point(130, 34);
            this.numAveWinLose.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numAveWinLose.Name = "numAveWinLose";
            this.numAveWinLose.Size = new System.Drawing.Size(42, 22);
            this.numAveWinLose.TabIndex = 1;
            this.numAveWinLose.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblAveWinLose
            // 
            this.lblAveWinLose.AutoSize = true;
            this.lblAveWinLose.Location = new System.Drawing.Point(16, 36);
            this.lblAveWinLose.Name = "lblAveWinLose";
            this.lblAveWinLose.Size = new System.Drawing.Size(105, 13);
            this.lblAveWinLose.TabIndex = 0;
            this.lblAveWinLose.Text = "Average Win/Lose";
            // 
            // btnResults
            // 
            this.btnResults.Font = new System.Drawing.Font("Segoe UI Black", 8.25F);
            this.btnResults.Location = new System.Drawing.Point(217, 440);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(102, 36);
            this.btnResults.TabIndex = 24;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = true;
            // 
            // btnRollFixture
            // 
            this.btnRollFixture.Font = new System.Drawing.Font("Segoe UI Black", 8.25F);
            this.btnRollFixture.Location = new System.Drawing.Point(12, 439);
            this.btnRollFixture.Name = "btnRollFixture";
            this.btnRollFixture.Size = new System.Drawing.Size(102, 37);
            this.btnRollFixture.TabIndex = 23;
            this.btnRollFixture.Text = "Roll Fixtures";
            this.btnRollFixture.UseVisualStyleBackColor = true;
            this.btnRollFixture.Click += new System.EventHandler(this.btnRollFixture_Click_1);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(115, 440);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(102, 37);
            this.btnApply.TabIndex = 21;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // btnClearList
            // 
            this.btnClearList.BackColor = System.Drawing.Color.Ivory;
            this.btnClearList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearList.Location = new System.Drawing.Point(295, 4);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(103, 29);
            this.btnClearList.TabIndex = 2;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = false;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // rdbResults
            // 
            this.rdbResults.AutoSize = true;
            this.rdbResults.Location = new System.Drawing.Point(125, 10);
            this.rdbResults.Name = "rdbResults";
            this.rdbResults.Size = new System.Drawing.Size(60, 17);
            this.rdbResults.TabIndex = 1;
            this.rdbResults.TabStop = true;
            this.rdbResults.Text = "Results";
            this.rdbResults.UseVisualStyleBackColor = true;
            // 
            // rdbFixtures
            // 
            this.rdbFixtures.AutoSize = true;
            this.rdbFixtures.Location = new System.Drawing.Point(10, 10);
            this.rdbFixtures.Name = "rdbFixtures";
            this.rdbFixtures.Size = new System.Drawing.Size(61, 17);
            this.rdbFixtures.TabIndex = 0;
            this.rdbFixtures.TabStop = true;
            this.rdbFixtures.Text = "Fixtures";
            this.rdbFixtures.UseVisualStyleBackColor = true;
            // 
            // pnlFixAndResults
            // 
            this.pnlFixAndResults.BackColor = System.Drawing.Color.DarkGray;
            this.pnlFixAndResults.Controls.Add(this.btnClearList);
            this.pnlFixAndResults.Controls.Add(this.rdbResults);
            this.pnlFixAndResults.Controls.Add(this.rdbFixtures);
            this.pnlFixAndResults.Location = new System.Drawing.Point(7, 15);
            this.pnlFixAndResults.Name = "pnlFixAndResults";
            this.pnlFixAndResults.Size = new System.Drawing.Size(449, 39);
            this.pnlFixAndResults.TabIndex = 18;
            // 
            // pnlFixture
            // 
            this.pnlFixture.AutoScroll = true;
            this.pnlFixture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFixture.Font = new System.Drawing.Font("Segoe UI Black", 8.25F);
            this.pnlFixture.Location = new System.Drawing.Point(7, 60);
            this.pnlFixture.Name = "pnlFixture";
            this.pnlFixture.Size = new System.Drawing.Size(449, 443);
            this.pnlFixture.TabIndex = 16;
            // 
            // FixtureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SoccerApplicationForMen.Properties.Resources.Emirates_Stadium_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlFixAndResults);
            this.Controls.Add(this.pnlFixture);
            this.Name = "FixtureControl";
            this.Size = new System.Drawing.Size(880, 520);
            this.Load += new System.EventHandler(this.FixtureControl_Load);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlTeamStats.ResumeLayout(false);
            this.pnlTeamStats.PerformLayout();
            this.tblTeamStats.ResumeLayout(false);
            this.tblTeamStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLosses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDraws)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGD)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGamesToCount)).EndInit();
            this.panel6.ResumeLayout(false);
            this.pnlAverageWinLose.ResumeLayout(false);
            this.pnlAverageWinLose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAveWinLose)).EndInit();
            this.pnlFixAndResults.ResumeLayout(false);
            this.pnlFixAndResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnRollFixture;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.RadioButton rdbResults;
        private System.Windows.Forms.RadioButton rdbFixtures;
        private System.Windows.Forms.Panel pnlFixAndResults;
        private System.Windows.Forms.FlowLayoutPanel pnlFixture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTeamStats;
        private System.Windows.Forms.Label lblTeamStats;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown numGamesToCount;
        private System.Windows.Forms.Label lblGamesToCount;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckedListBox chkConsistancy;
        private System.Windows.Forms.Panel pnlAverageWinLose;
        private System.Windows.Forms.RadioButton rdbOFF;
        private System.Windows.Forms.RadioButton rdbON;
        private System.Windows.Forms.NumericUpDown numAveWinLose;
        private System.Windows.Forms.Label lblAveWinLose;
        private System.Windows.Forms.TableLayoutPanel tblTeamStats;
        private System.Windows.Forms.Label lblPlayed;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblDraws;
        private System.Windows.Forms.Label lblGoalDiff;
        private System.Windows.Forms.NumericUpDown numPlayed;
        private System.Windows.Forms.NumericUpDown numWins;
        private System.Windows.Forms.NumericUpDown numLosses;
        private System.Windows.Forms.NumericUpDown numDraws;
        private System.Windows.Forms.NumericUpDown numGD;
        private System.Windows.Forms.ComboBox cmbGD;
        private System.Windows.Forms.ComboBox cmbDraws;
        private System.Windows.Forms.ComboBox cmbLosses;
        private System.Windows.Forms.ComboBox cmbWins;
        private System.Windows.Forms.ComboBox cmbPlayed;
        private System.Windows.Forms.ComboBox cmbCustomStats;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCustomStats;

    }
}
