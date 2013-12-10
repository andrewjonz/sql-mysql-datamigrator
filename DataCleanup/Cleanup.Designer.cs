namespace DataCleanup
{
    partial class Cleanup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cleanup));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RetrievingTables = new System.Windows.Forms.PictureBox();
            this.ViewLogBtn = new System.Windows.Forms.Button();
            this.TimeTaken_Execute = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ConnectionProperties = new System.Windows.Forms.Button();
            this.TablesListPanel = new System.Windows.Forms.Panel();
            this.DestLabel1 = new System.Windows.Forms.Label();
            this.SourceLabel1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MatchBtn = new System.Windows.Forms.Button();
            this.MySQLTablesListBox = new System.Windows.Forms.ListBox();
            this.SelectedLabel = new System.Windows.Forms.Label();
            this.GenerateScripts = new System.Windows.Forms.Button();
            this.l1 = new System.Windows.Forms.Label();
            this.SelectAllTables = new System.Windows.Forms.CheckBox();
            this.TablesListbox = new System.Windows.Forms.CheckedListBox();
            this.LogPanel = new System.Windows.Forms.Panel();
            this.DestLabel_Value = new System.Windows.Forms.Label();
            this.SourceLabel_Value = new System.Windows.Forms.Label();
            this.DestLabel = new System.Windows.Forms.Label();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.LogHeading = new System.Windows.Forms.Label();
            this.ListLog = new System.Windows.Forms.RichTextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.ElapsedTime = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetrievingTables)).BeginInit();
            this.panel3.SuspendLayout();
            this.TablesListPanel.SuspendLayout();
            this.LogPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 499);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(664, 6);
            this.progressBar1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(664, 500);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RetrievingTables);
            this.tabPage3.Controls.Add(this.ViewLogBtn);
            this.tabPage3.Controls.Add(this.TimeTaken_Execute);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.LogPanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(656, 472);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "                                           Database Export                       " +
    "                   ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RetrievingTables
            // 
            this.RetrievingTables.Image = global::DataCleanup.Properties.Resources._3011;
            this.RetrievingTables.Location = new System.Drawing.Point(310, 156);
            this.RetrievingTables.Name = "RetrievingTables";
            this.RetrievingTables.Size = new System.Drawing.Size(35, 34);
            this.RetrievingTables.TabIndex = 8;
            this.RetrievingTables.TabStop = false;
            this.RetrievingTables.Visible = false;
            // 
            // ViewLogBtn
            // 
            this.ViewLogBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ViewLogBtn.Location = new System.Drawing.Point(573, 444);
            this.ViewLogBtn.Name = "ViewLogBtn";
            this.ViewLogBtn.Size = new System.Drawing.Size(75, 23);
            this.ViewLogBtn.TabIndex = 14;
            this.ViewLogBtn.Text = "Show Log";
            this.ViewLogBtn.UseVisualStyleBackColor = true;
            this.ViewLogBtn.Visible = false;
            this.ViewLogBtn.Click += new System.EventHandler(this.ViewLogBtn_Click);
            // 
            // TimeTaken_Execute
            // 
            this.TimeTaken_Execute.AutoSize = true;
            this.TimeTaken_Execute.BackColor = System.Drawing.Color.White;
            this.TimeTaken_Execute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TimeTaken_Execute.Location = new System.Drawing.Point(534, 10);
            this.TimeTaken_Execute.Name = "TimeTaken_Execute";
            this.TimeTaken_Execute.Size = new System.Drawing.Size(116, 15);
            this.TimeTaken_Execute.TabIndex = 10;
            this.TimeTaken_Execute.Text = "Elapsed time 0 : 0 : 0";
            this.TimeTaken_Execute.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.ConnectionProperties);
            this.panel3.Controls.Add(this.TablesListPanel);
            this.panel3.Location = new System.Drawing.Point(8, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 464);
            this.panel3.TabIndex = 9;
            // 
            // ConnectionProperties
            // 
            this.ConnectionProperties.BackColor = System.Drawing.Color.White;
            this.ConnectionProperties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConnectionProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectionProperties.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ConnectionProperties.FlatAppearance.BorderSize = 0;
            this.ConnectionProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectionProperties.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionProperties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConnectionProperties.Image = global::DataCleanup.Properties.Resources._1363015584_35950;
            this.ConnectionProperties.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConnectionProperties.Location = new System.Drawing.Point(199, 3);
            this.ConnectionProperties.Name = "ConnectionProperties";
            this.ConnectionProperties.Size = new System.Drawing.Size(231, 48);
            this.ConnectionProperties.TabIndex = 2;
            this.ConnectionProperties.Text = "Set Connection properties      ";
            this.ConnectionProperties.UseVisualStyleBackColor = false;
            this.ConnectionProperties.Click += new System.EventHandler(this.ConnectionProperties_Click);
            // 
            // TablesListPanel
            // 
            this.TablesListPanel.BackColor = System.Drawing.Color.White;
            this.TablesListPanel.Controls.Add(this.DestLabel1);
            this.TablesListPanel.Controls.Add(this.SourceLabel1);
            this.TablesListPanel.Controls.Add(this.label6);
            this.TablesListPanel.Controls.Add(this.MatchBtn);
            this.TablesListPanel.Controls.Add(this.MySQLTablesListBox);
            this.TablesListPanel.Controls.Add(this.SelectedLabel);
            this.TablesListPanel.Controls.Add(this.GenerateScripts);
            this.TablesListPanel.Controls.Add(this.l1);
            this.TablesListPanel.Controls.Add(this.SelectAllTables);
            this.TablesListPanel.Controls.Add(this.TablesListbox);
            this.TablesListPanel.Location = new System.Drawing.Point(20, 40);
            this.TablesListPanel.Name = "TablesListPanel";
            this.TablesListPanel.Size = new System.Drawing.Size(596, 421);
            this.TablesListPanel.TabIndex = 7;
            this.TablesListPanel.Visible = false;
            // 
            // DestLabel1
            // 
            this.DestLabel1.AutoSize = true;
            this.DestLabel1.ForeColor = System.Drawing.Color.Black;
            this.DestLabel1.Location = new System.Drawing.Point(360, 47);
            this.DestLabel1.Name = "DestLabel1";
            this.DestLabel1.Size = new System.Drawing.Size(0, 15);
            this.DestLabel1.TabIndex = 11;
            // 
            // SourceLabel1
            // 
            this.SourceLabel1.AutoSize = true;
            this.SourceLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SourceLabel1.Location = new System.Drawing.Point(0, 26);
            this.SourceLabel1.Name = "SourceLabel1";
            this.SourceLabel1.Size = new System.Drawing.Size(0, 15);
            this.SourceLabel1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(359, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "List of tables from Destination";
            // 
            // MatchBtn
            // 
            this.MatchBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MatchBtn.Location = new System.Drawing.Point(237, 201);
            this.MatchBtn.Name = "MatchBtn";
            this.MatchBtn.Size = new System.Drawing.Size(119, 35);
            this.MatchBtn.TabIndex = 9;
            this.MatchBtn.Text = "<- Match Both ->";
            this.MatchBtn.UseVisualStyleBackColor = true;
            this.MatchBtn.Click += new System.EventHandler(this.MatchBtn_Click);
            // 
            // MySQLTablesListBox
            // 
            this.MySQLTablesListBox.BackColor = System.Drawing.Color.White;
            this.MySQLTablesListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MySQLTablesListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MySQLTablesListBox.FormattingEnabled = true;
            this.MySQLTablesListBox.ItemHeight = 15;
            this.MySQLTablesListBox.Location = new System.Drawing.Point(362, 68);
            this.MySQLTablesListBox.Name = "MySQLTablesListBox";
            this.MySQLTablesListBox.Size = new System.Drawing.Size(229, 274);
            this.MySQLTablesListBox.Sorted = true;
            this.MySQLTablesListBox.TabIndex = 8;
            // 
            // SelectedLabel
            // 
            this.SelectedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SelectedLabel.Location = new System.Drawing.Point(106, 50);
            this.SelectedLabel.Name = "SelectedLabel";
            this.SelectedLabel.Size = new System.Drawing.Size(131, 13);
            this.SelectedLabel.TabIndex = 6;
            this.SelectedLabel.Text = "135 of 135 Selected ";
            this.SelectedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.SelectedLabel.Visible = false;
            // 
            // GenerateScripts
            // 
            this.GenerateScripts.BackColor = System.Drawing.Color.White;
            this.GenerateScripts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GenerateScripts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateScripts.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.GenerateScripts.FlatAppearance.BorderSize = 0;
            this.GenerateScripts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateScripts.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateScripts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GenerateScripts.Image = global::DataCleanup.Properties.Resources.Sql_runner;
            this.GenerateScripts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GenerateScripts.Location = new System.Drawing.Point(190, 380);
            this.GenerateScripts.Name = "GenerateScripts";
            this.GenerateScripts.Size = new System.Drawing.Size(200, 42);
            this.GenerateScripts.TabIndex = 1;
            this.GenerateScripts.Text = "Load to MySQL database      ";
            this.GenerateScripts.UseVisualStyleBackColor = false;
            this.GenerateScripts.Click += new System.EventHandler(this.GenerateScripts_Click);
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.l1.Location = new System.Drawing.Point(0, 5);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(140, 14);
            this.l1.TabIndex = 5;
            this.l1.Text = "List of tables from Source";
            // 
            // SelectAllTables
            // 
            this.SelectAllTables.AutoSize = true;
            this.SelectAllTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SelectAllTables.Location = new System.Drawing.Point(3, 48);
            this.SelectAllTables.Name = "SelectAllTables";
            this.SelectAllTables.Size = new System.Drawing.Size(75, 19);
            this.SelectAllTables.TabIndex = 4;
            this.SelectAllTables.Text = "Select All";
            this.SelectAllTables.UseVisualStyleBackColor = true;
            this.SelectAllTables.CheckedChanged += new System.EventHandler(this.SelectAllTables_CheckedChanged_1);
            // 
            // TablesListbox
            // 
            this.TablesListbox.BackColor = System.Drawing.Color.White;
            this.TablesListbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TablesListbox.FormattingEnabled = true;
            this.TablesListbox.Location = new System.Drawing.Point(2, 69);
            this.TablesListbox.Name = "TablesListbox";
            this.TablesListbox.Size = new System.Drawing.Size(229, 292);
            this.TablesListbox.Sorted = true;
            this.TablesListbox.TabIndex = 3;
            this.TablesListbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TablesListbox_ItemCheck);
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.DestLabel_Value);
            this.LogPanel.Controls.Add(this.SourceLabel_Value);
            this.LogPanel.Controls.Add(this.DestLabel);
            this.LogPanel.Controls.Add(this.SourceLabel);
            this.LogPanel.Controls.Add(this.LogHeading);
            this.LogPanel.Controls.Add(this.ListLog);
            this.LogPanel.Controls.Add(this.BackBtn);
            this.LogPanel.Location = new System.Drawing.Point(90, 52);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(467, 364);
            this.LogPanel.TabIndex = 13;
            this.LogPanel.Visible = false;
            // 
            // DestLabel_Value
            // 
            this.DestLabel_Value.AutoSize = true;
            this.DestLabel_Value.ForeColor = System.Drawing.Color.White;
            this.DestLabel_Value.Location = new System.Drawing.Point(127, 58);
            this.DestLabel_Value.Name = "DestLabel_Value";
            this.DestLabel_Value.Size = new System.Drawing.Size(0, 15);
            this.DestLabel_Value.TabIndex = 17;
            // 
            // SourceLabel_Value
            // 
            this.SourceLabel_Value.AutoSize = true;
            this.SourceLabel_Value.ForeColor = System.Drawing.Color.White;
            this.SourceLabel_Value.Location = new System.Drawing.Point(127, 36);
            this.SourceLabel_Value.Name = "SourceLabel_Value";
            this.SourceLabel_Value.Size = new System.Drawing.Size(0, 15);
            this.SourceLabel_Value.TabIndex = 17;
            // 
            // DestLabel
            // 
            this.DestLabel.AutoSize = true;
            this.DestLabel.ForeColor = System.Drawing.Color.White;
            this.DestLabel.Location = new System.Drawing.Point(51, 58);
            this.DestLabel.Name = "DestLabel";
            this.DestLabel.Size = new System.Drawing.Size(71, 15);
            this.DestLabel.TabIndex = 16;
            this.DestLabel.Text = "Destination:";
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.ForeColor = System.Drawing.Color.White;
            this.SourceLabel.Location = new System.Drawing.Point(51, 36);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(47, 15);
            this.SourceLabel.TabIndex = 16;
            this.SourceLabel.Text = "Source:";
            // 
            // LogHeading
            // 
            this.LogHeading.AutoSize = true;
            this.LogHeading.BackColor = System.Drawing.Color.White;
            this.LogHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogHeading.Location = new System.Drawing.Point(51, 153);
            this.LogHeading.Name = "LogHeading";
            this.LogHeading.Size = new System.Drawing.Size(73, 13);
            this.LogHeading.TabIndex = 15;
            this.LogHeading.Text = "Log details:";
            // 
            // ListLog
            // 
            this.ListLog.BackColor = System.Drawing.Color.White;
            this.ListLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ListLog.Location = new System.Drawing.Point(53, 169);
            this.ListLog.Name = "ListLog";
            this.ListLog.ReadOnly = true;
            this.ListLog.Size = new System.Drawing.Size(354, 127);
            this.ListLog.TabIndex = 14;
            this.ListLog.Text = "";
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(186, 308);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(656, 472);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "                                           About                                 " +
    "           ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(114, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(537, 105);
            this.label10.TabIndex = 2;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 94);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(153, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(357, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Copyright © 2013. All Rights Reserved Andrew Jones && Jijo George";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(114, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Version 1.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(108, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 38);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cleanup";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork_1);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.WorkerReportsProgress = true;
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted);
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.Interval = 1000;
            this.ElapsedTime.Tick += new System.EventHandler(this.ElapsedTime_Tick);
            // 
            // Cleanup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 505);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Cleanup";
            this.Text = "Cleanup";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetrievingTables)).EndInit();
            this.panel3.ResumeLayout(false);
            this.TablesListPanel.ResumeLayout(false);
            this.TablesListPanel.PerformLayout();
            this.LogPanel.ResumeLayout(false);
            this.LogPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button ConnectionProperties;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.Panel TablesListPanel;
        private System.Windows.Forms.CheckBox SelectAllTables;
        private System.Windows.Forms.CheckedListBox TablesListbox;
        private System.Windows.Forms.Button GenerateScripts;
        private System.Windows.Forms.PictureBox RetrievingTables;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer ElapsedTime;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label TimeTaken_Execute;
        private System.Windows.Forms.Panel LogPanel;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.RichTextBox ListLog;
        private System.Windows.Forms.Button ViewLogBtn;
        private System.Windows.Forms.Label LogHeading;
        private System.Windows.Forms.Label SelectedLabel;
        private System.Windows.Forms.Label DestLabel;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label DestLabel_Value;
        private System.Windows.Forms.Label SourceLabel_Value;
        private System.Windows.Forms.ListBox MySQLTablesListBox;
        private System.Windows.Forms.Button MatchBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label DestLabel1;
        private System.Windows.Forms.Label SourceLabel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
    }
}

