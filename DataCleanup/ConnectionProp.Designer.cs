namespace DataCleanup
{
    partial class ConnectionProp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionProp));
            this.MSSQL_CS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MYSQL_CS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Save_CS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MSSQL_CS
            // 
            this.MSSQL_CS.BackColor = System.Drawing.Color.White;
            this.MSSQL_CS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MSSQL_CS.ForeColor = System.Drawing.Color.Black;
            this.MSSQL_CS.Location = new System.Drawing.Point(120, 49);
            this.MSSQL_CS.Name = "MSSQL_CS";
            this.MSSQL_CS.Size = new System.Drawing.Size(549, 20);
            this.MSSQL_CS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source (MSSQL)";
            // 
            // MYSQL_CS
            // 
            this.MYSQL_CS.BackColor = System.Drawing.Color.White;
            this.MYSQL_CS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MYSQL_CS.ForeColor = System.Drawing.Color.Black;
            this.MYSQL_CS.Location = new System.Drawing.Point(120, 77);
            this.MYSQL_CS.Name = "MYSQL_CS";
            this.MYSQL_CS.Size = new System.Drawing.Size(549, 20);
            this.MYSQL_CS.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination (MySQL)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(399, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Set your connection strings here. e.g. Database=;Data Source=;User Id=;Password\r\n" +
    "Please follow the connection string format";
            // 
            // Save_CS
            // 
            this.Save_CS.BackColor = System.Drawing.Color.Transparent;
            this.Save_CS.BackgroundImage = global::DataCleanup.Properties.Resources.save;
            this.Save_CS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Save_CS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_CS.FlatAppearance.BorderSize = 0;
            this.Save_CS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_CS.ForeColor = System.Drawing.Color.Transparent;
            this.Save_CS.Location = new System.Drawing.Point(634, 6);
            this.Save_CS.Name = "Save_CS";
            this.Save_CS.Size = new System.Drawing.Size(36, 34);
            this.Save_CS.TabIndex = 5;
            this.Save_CS.Tag = "Save & Close";
            this.Save_CS.UseVisualStyleBackColor = false;
            this.Save_CS.Click += new System.EventHandler(this.Save_CS_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(563, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Save && Close";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ConnectionProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 114);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Save_CS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MYSQL_CS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MSSQL_CS);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectionProp";
            this.Text = "Connection properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MSSQL_CS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MYSQL_CS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Save_CS;
        private System.Windows.Forms.Label label4;
    }
}