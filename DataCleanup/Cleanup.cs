using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.Common;
using System.Transactions;
using System.Threading;
using System.Resources;
using System.Collections;

namespace DataCleanup
{
    /// <summary>
    /// Form1
    /// </summary>
    public partial class Cleanup : Form
    {
        #region Constants

        const string SQL_SERVERNAME = "sql_servername";
        const string SQL_USERNAME = "sql_username";
        const string SQL_PASSWORD = "sql_password";
        const string SQL_DATABASE = "sql_database";

        /// <summary>
        /// SERVER_CREDENTIALS_FILE_NAME_MSSQL
        /// </summary>
        const string SERVER_CREDENTIALS_FILE_NAME_MSSQL = "ServerCredentials_mssql.resx";

        /// <summary>
        /// SERVER_CREDENTIALS_FILE_NAME_MYSQL
        /// </summary>
        const string SERVER_CREDENTIALS_FILE_NAME_MYSQL = "ServerCredentials_mysql.resx";

        #endregion

        #region Data Export

        const string EXPORT_SELECT_ALL_TABLES = @"SELECT DISTINCT ST.name AS 'tablename', 'INSERT INTO `' + ST.name + '` (' + SCC.tablename + ') VALUES ' AS 'insertscript' FROM sys.tables ST
                                                                                    INNER JOIN
                                                                                    (
                                                                                    	SELECT 
                                                                                    		SUBSTRING
                                                                                    		((
                                                                                    			SELECT ', `'+ CONVERT(VARCHAR(500), SCS.name) + '`'
                                                                                    			from sys.columns SCS 
                                                                                    			where SCS.object_id = SC.object_id	
                                                                                    			FOR XML PATH('')		
                                                                                    		) ,3,1000) AS tablename,SC.object_id AS obj_id
                                                                                    	FROM  sys.columns SC
                                                                                    )SCC ON SCC.obj_id = ST.object_id
                                                                                    WHERE type = 'U' ORDER BY ST.name";

        const string EXPORT_SELECT_ALL_TABLES_FIELDS = @"SELECT DISTINCT ST.name as 'tablename', SCC.tablename  as 'insertscript' FROM sys.tables ST
                                                                                                    INNER JOIN
                                                                                                    (
                                                                                                        SELECT
                                                                                                            SUBSTRING
                                                                                                            ((
                                                                                                                SELECT ', ['+ CONVERT(VARCHAR(500), scS.name) +']'
                                                                                                                from sys.columns SCS
                                                                                                                where SCS.object_id = SC.object_id  
                                                                                                                FOR XML PATH('')      
                                                                                                            ) ,3,1000) AS tablename, SC.object_id AS obj_id
                                                                                                        FROM  sys.columns SC
                                                                                                    )
                                                                                                    SCC    ON SCC.obj_id = ST.object_id
                                                                                                    WHERE type = 'U' ORDER BY ST.name";

        const string EXPORT_SELECT_ALL_TABLES_MYSQL = @"SELECT IT.TABLE_NAME FROM information_schema.TABLES IT WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = ";

        #endregion

        #region Database Connection variables

        private DbProviderFactory factory;

        public DbProviderFactory Factory
        {
            get
            {
                return factory;
            }
        }

        private DbConnection cn;

        private DbTransaction trans;

        private DbCommand cmd;

        private DbDataReader rdr;

        #endregion

        #region Constructor and Form load

        /// <summary>
        /// Initializes a new instance of the <see cref="Cleanup"/> class.
        /// </summary>
        public Cleanup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitializeDataExport();
        }

        #endregion

        #region Connection

        /// <summary>
        /// Resets this instance.
        /// </summary>
        private void Reset()
        {
            progressBar1.Invoke((Action)(() => this.progressBar1.Value = 0));
            //if (this.DealerIDTxtbox.Enabled)
            //{
            //    DealerIDTxtbox.Invoke((Action)(() => this.DealerIDTxtbox.Text = string.Empty));
            //}

            //LocalRadioButton.Invoke((Action)(() => this.LocalRadioButton.Checked = true));
            //MSSQL_RB.Invoke((Action)(() => this.MSSQL_RB.Checked = true));
            //ClearCustomers.Invoke((Action)(() => this.ClearCustomers.Checked = true));
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns></returns>
        public DbCommand CreateCommand(string commandText, CommandType commandType)
        {
            DbCommand command = Factory.CreateCommand();

            command.Connection = cn;
            command.CommandText = commandText;
            command.CommandType = commandType;

            command.CommandTimeout = 999999;

            return command;
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns></returns>
        public DbParameter AddParameter(DbCommand command, string parameterName, object parameterValue)
        {
            DbParameter parameter = Factory.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;

            command.Parameters.Add(parameter);

            return parameter;
        }

        /// <summary>
        /// Handles the Click event of the tabControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tabControl1_Click(object sender, EventArgs e)
        {
            //this.GetServerCredentials();
        }

        /// <summary>
        /// Sets the connection strings for cleanup.
        /// </summary>
        /// <param name="cs">The cs.</param>
        public void SetConnectionStringsForCleanup(string cs)
        {
            if (!string.IsNullOrEmpty(cs))
            {
                connectionString_Cleanup = cs;
            }
        }

        /// <summary>
        /// Displays the connection string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        private string DisplayConnectionString(string source)
        {
            string[] delimiter = { "=", ";" };

            // Source label
            string[] sql = source.Split(delimiter, StringSplitOptions.None);
            return GetFormattedSourceAndDest(sql);
        }

        #endregion

        #region Data Export

        /// <summary>
        /// Initializes the data export.
        /// </summary>
        private void InitializeDataExport()
        {
            this.GenerateScripts.Enabled = true;
            this.hasErrors = false;
            this.panel3.Visible = true;
            this.panel3.Enabled = true;
            this.LogPanel.Visible = false;
            //this.CancelBtn.Visible = false;
            this.RetrievingTables.Visible = false;
            this.ViewLogBtn.Visible = false;
            this.TimeTaken_Execute.Visible = false;
            queryToExecute = new Dictionary<string, StringBuilder>();
            totalSeconds = 1;
            TablesListbox.Invoke((Action)(() => this.TablesListbox.Refresh()));
        }

        /// <summary>
        /// Handles the Click event of the GenerateScripts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GenerateScripts_Click(object sender, EventArgs e)
        {
            var lob = (IList)this.Invoke(new Func<IList>(() => TablesListbox.CheckedItems.Cast<object>().ToList()));
            if (lob != null && lob.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to load the MSSQL Data to the MYSQL Database", "MySQL Database", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (MessageBox.Show("All the existing data in the MySQL database will be cleared, Are you sure ?", "MySQL Database", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.ElapsedTime.Enabled = true;
                        this.TimeTaken_Execute.Visible = true;
                        this.ElapsedTime.Start();

                        progressBar1.Invoke((Action)(() => progressBar1.Value = 0));
                        this.panel3.Visible = false;
                        this.LogPanel.Visible = true;
                        //this.CancelBtn.Visible = true;
                        this.RetrievingTables.Visible = true;
                        this.RetrievingTables.BringToFront();

                        this.backgroundWorker2.RunWorkerAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("No tables were selected..!!!");
            }
        }

        /// <summary>
        /// Gets all tables.
        /// </summary>
        private void GetAllTables()
        {
            GetAllMSSQLTables();
            GetAllMYSQLTables();
            ListAllTables();
        }

        /// <summary>
        /// Gets all MSSQL tables.
        /// </summary>
        private void GetAllMSSQLTables()
        {
            string connectionString = connectionString_MSSQL_Export;
            tables_insert = new Dictionary<string, string>();
            tables_fields = new Dictionary<string, string>();

            try
            {
                // Set the connection
                this.factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                cn = Factory.CreateConnection();
                cn.ConnectionString = connectionString;
                cn.Open();

                using (TransactionScope scope = new TransactionScope())
                {
                    cmd = this.CreateCommand(EXPORT_SELECT_ALL_TABLES, CommandType.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        tables_insert = new Dictionary<string, string>();
                        while (rdr.Read())
                        {
                            tables_insert.Add(rdr["tablename"].ToString(), rdr["insertscript"].ToString());
                        }
                    }

                    rdr.Close();

                    cmd = this.CreateCommand(EXPORT_SELECT_ALL_TABLES_FIELDS, CommandType.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        tables_fields = new Dictionary<string, string>();
                        while (rdr.Read())
                        {
                            tables_fields.Add(rdr["tablename"].ToString(), rdr["insertscript"].ToString());
                        }
                    }

                    rdr.Close();
                    scope.Complete();
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                RetrievingTables.Invoke((Action)(() => this.RetrievingTables.Visible = false));
                MessageBox.Show(ex.Message);
                hasErrors = true;
            }
        }

        /// <summary>
        /// Gets all MYSQL tables.
        /// </summary>
        private void GetAllMYSQLTables()
        {
            string connectionString = connectionString_MYSQL_Export;
            string errorMsg = string.Empty;

            try
            {
                // Set the connection
                this.factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                cn = Factory.CreateConnection();
                cn.ConnectionString = connectionString;

                // Open con and Begin Trans
                cn.Open();
                trans = cn.BeginTransaction();

                cmd = this.CreateCommand(EXPORT_SELECT_ALL_TABLES_MYSQL + "'" + cn.Database + "'", CommandType.Text);
                cmd.Transaction = trans;
                rdr = cmd.ExecuteReader();

                if (rdr != null)
                {
                    tables_mysql_db = new List<string>();
                    while (rdr.Read())
                    {
                        tables_mysql_db.Add(rdr["TABLE_NAME"].ToString());
                    }
                }

                rdr.Close();

                // Close con and Commit Trans
                trans.Commit();
                cn.Close();
            }
            catch (Exception ex)
            {
                hasErrors = true;
                if (trans != null)
                {
                    trans.Rollback();
                }

                RetrievingTables.Invoke((Action)(() => this.RetrievingTables.Visible = false));
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Gets the table data.
        /// </summary>
        /// <param name="tablesList">The tables list.</param>
        private void GetTableData(Dictionary<string, string> tablesList, Dictionary<string, string> tables_fields, string connectionString)
        {
            int count = 0;
            string fields, initialQuery;
            StringBuilder sb = new StringBuilder();

            try
            {
                if (tablesList != null && tablesList.Count > 0 && tables_fields != null && tables_fields.Count > 0)
                {
                    isRunning = true;
                    ListLog.Invoke((Action)(() => this.ListLog.Clear()));

                    // Append to Log
                    ListLog.Invoke((Action)(() => this.ListLog.AppendText("Query generation in progress..." + Environment.NewLine)));

                    // Set the connection
                    this.factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    cn = Factory.CreateConnection();
                    cn.ConnectionString = connectionString;
                    cn.Open();

                    using (TransactionScope scope = new TransactionScope())
                    {
                        maxProgress = (tablesList.Keys.Count * 2) + 2;
                        progressBar1.Invoke((Action)(() => progressBar1.Maximum = maxProgress));

                        // Set foreign_key_checks = 0;
                        sb.Append("SET foreign_key_checks = 0;" + Environment.NewLine);

                        // Initialize the query list
                        queryToExecute = new Dictionary<string, StringBuilder>();
                        queryToExecute.Add("FK_Disable", sb);

                        foreach (string table in tablesList.Keys)
                        {
                            sb = new StringBuilder();
                            tables_fields.TryGetValue(table, out fields);
                            cmd = this.CreateCommand("SELECT " + fields + " FROM [" + table + "]", CommandType.Text);
                            rdr = cmd.ExecuteReader();
                            if (rdr != null)
                            {
                                tablesList.TryGetValue(table, out initialQuery);

                                // Append the delete script
                                sb.Append("SET SQL_SAFE_UPDATES = 0;" + Environment.NewLine);
                                sb.Append("DELETE FROM `" + table + "`;" + Environment.NewLine);
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        // Append the insert script
                                        sb.Append(initialQuery);

                                        sb.Append("(");
                                        for (int i = 0; i < rdr.FieldCount; i++)
                                        {
                                            // Format the quote ' values.
                                            if (rdr[i].ToString().Contains("'"))
                                            {
                                                string[] s = rdr[i].ToString().Split('\'');
                                                sb.Append("'");
                                                if (i + 1 == rdr.FieldCount)
                                                {
                                                    sb.Append("" + s[0].ToString() + "''" + s[1].ToString() + "'");
                                                }
                                                else
                                                {
                                                    sb.Append("" + s[0].ToString() + "''" + s[1].ToString() + "', ");
                                                }
                                            }
                                            else
                                            {
                                                // Format the data according to the datatype.
                                                if (rdr[i] == (object)System.DBNull.Value)
                                                {
                                                    if (i + 1 == rdr.FieldCount)
                                                    {
                                                        sb.Append("NULL");
                                                    }
                                                    else
                                                    {
                                                        sb.Append("NULL, ");
                                                    }
                                                }
                                                else if (rdr[i] is long || rdr[i] is short)
                                                {
                                                    if (i + 1 == rdr.FieldCount)
                                                    {
                                                        sb.Append(" " + rdr[i].ToString());
                                                    }
                                                    else
                                                    {
                                                        sb.Append(" " + rdr[i].ToString() + ", ");
                                                    }
                                                }
                                                else if (rdr[i] is bool)
                                                {
                                                    if (i + 1 == rdr.FieldCount)
                                                    {
                                                        sb.Append(rdr[i].ToString().ToLower().Equals("false") ? 0 : 1);
                                                    }
                                                    else
                                                    {
                                                        sb.Append(rdr[i].ToString().ToLower().Equals("false") ? 0 + "," : 1 + ",");
                                                    }
                                                }
                                                else if (rdr[i] is DateTime)
                                                {
                                                    sb.Append("'");
                                                    if (i + 1 == rdr.FieldCount)
                                                    {
                                                        sb.Append("" + Convert.ToDateTime(rdr[i]).ToString("yyyy/MM/dd HH:mm:ss") + "'");
                                                    }
                                                    else
                                                    {
                                                        sb.Append("" + Convert.ToDateTime(rdr[i]).ToString("yyyy/MM/dd HH:mm:ss") + "', ");
                                                    }
                                                }
                                                else
                                                {
                                                    sb.Append("'");
                                                    if (i + 1 == rdr.FieldCount)
                                                    {
                                                        sb.Append("" + rdr[i].ToString() + "'");
                                                    }
                                                    else
                                                    {
                                                        sb.Append("" + rdr[i].ToString() + "', ");
                                                    }
                                                }
                                            }
                                        }
                                        sb.Append(");" + Environment.NewLine);
                                        count++;
                                    }
                                }
                            }

                            rdr.Close();

                            // Assign sb to the global variable
                            queryToExecute.Add(table, sb);

                            // Increment the progressbar.
                            progressBar1.Invoke((Action)(() => this.progressBar1.Value += 1));
                        }
                    }

                    isRunning = false;

                    // Append to Log
                    ListLog.Invoke((Action)(() => this.ListLog.AppendText("Query generation is completed." + Environment.NewLine + "Data exporting started..." + Environment.NewLine)));
                }

                // Set foreign_key_checks = 1;
                sb = new StringBuilder();
                sb.Append("SET foreign_key_checks = 1;" + Environment.NewLine);
                queryToExecute.Add("FK_Enabled", sb);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                ListLog.Invoke((Action)(() => this.ListLog.AppendText("Error in Query generation." + Environment.NewLine)));
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the ConnectionProperties control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ConnectionProperties_Click(object sender, EventArgs e)
        {
            this.RetrievingTables.Visible = false;
            this.TablesListPanel.Visible = false;
            this.TablesListbox.Visible = false;
            this.GenerateScripts.Enabled = false;
            this.TimeTaken_Execute.Visible = false;

            ConnectionProp cs = new ConnectionProp(this);
            if (cs.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                if (!string.IsNullOrEmpty(connectionString_MSSQL_Export) && !string.IsNullOrEmpty(connectionString_MYSQL_Export))
                {
                    if (!(connectionString_MYSQL_Export.LastIndexOf(';') + 1 == connectionString_MYSQL_Export.Length))
                    {
                        connectionString_MYSQL_Export = connectionString_MYSQL_Export + ";";
                    }

                    this.RetrievingTables.Visible = true;
                    this.RetrievingTables.BringToFront();
                    this.DisplaySourceAndDest(connectionString_MSSQL_Export, connectionString_MYSQL_Export);
                    this.backgroundWorker3.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// Sets the connectionstring_ export.
        /// </summary>
        public void SetConnectionstring_Export(string mssql_cs, string mysql_cs)
        {
            if (!string.IsNullOrEmpty(mssql_cs) && !string.IsNullOrEmpty(mysql_cs))
            {
                connectionString_MSSQL_Export = mssql_cs;
                connectionString_MYSQL_Export = mysql_cs;
            }
        }

        /// <summary>
        /// Handles the 1 event of the backgroundWorker2_DoWork control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker2_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> tablesList = null;
            string val;

            if (tables_insert != null && tables_insert.Count > 0)
            {
                tablesList = new Dictionary<string, string>();
                var lob = (IList)this.Invoke(new Func<IList>(() => TablesListbox.CheckedItems.Cast<object>().ToList()));
                foreach (string item in lob)
                {
                    tables_insert.TryGetValue(item, out val);
                    tablesList.Add(item, val);
                }
            }

            GetTableData(tablesList, tables_fields, connectionString_MSSQL_Export);
        }

        /// <summary>
        /// Handles the DoWork event of the backgroundWorker3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            this.GetAllTables();
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the backgroundWorker3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!hasErrors)
            {
                this.RetrievingTables.Visible = false;
                this.TablesListPanel.Visible = true;
                this.TablesListbox.Visible = true;
                this.GenerateScripts.Enabled = true;
                this.SelectedLabel.Visible = true;
            }
            else
            {
                this.RetrievingTables.Visible = false;
            }
        }

        /// <summary>
        /// Lists all tables.
        /// </summary>
        private void ListAllTables()
        {
            // MSSQL Tables
            if (tables_insert != null && tables_insert.Count > 0)
            {
                TablesListbox.Invoke((Action)(() => TablesListbox.Items.Clear()));
                foreach (string item in tables_insert.Keys)
                {
                    TablesListbox.Invoke((Action)(() => TablesListbox.Items.Add(item)));
                }
                this.SelectedLabel.Text = "0 of " + tables_insert.Count + " selected";
            }

            // MySQL Tables
            if (tables_mysql_db != null && tables_mysql_db.Count > 0)
            {
                MySQLTablesListBox.Invoke((Action)(() => this.MySQLTablesListBox.Items.Clear()));
                foreach (string item in tables_mysql_db)
                {
                    MySQLTablesListBox.Invoke((Action)(() => this.MySQLTablesListBox.Items.Add(item)));
                }
            }
        }

        /// <summary>
        /// Gets the mysql DB connection_ execute.
        /// </summary>
        private void GetMysqlDBConnection_Execute()
        {
            string connectionString = connectionString_MYSQL_Export + "Connection Timeout=180";
            string errorMsg = string.Empty;
            StringBuilder item;

            try
            {
                if (queryToExecute != null && queryToExecute.Count > 0)
                {
                    // Set the connection
                    this.factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                    cn = Factory.CreateConnection();
                    cn.ConnectionString = connectionString;
                    isRunning = true;

                    foreach (string table in queryToExecute.Keys)
                    {
                        // Open con and Begin Trans
                        cn.Open();
                        trans = cn.BeginTransaction();

                        errorMsg = table;

                        // Append to Log
                        ListLog.Invoke((Action)(() => this.ListLog.AppendText(table + " Executing..." + Environment.NewLine)));
                        ListLog.Invoke((Action)(() => this.ListLog.Focus()));

                        queryToExecute.TryGetValue(table, out item);
                        cmd = this.CreateCommand(item.ToString(), CommandType.Text);
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();

                        if (progressBar1.Value < maxProgress)
                        {
                            progressBar1.Invoke((Action)(() => this.progressBar1.Value += 1));
                        }

                        // Append to Log
                        ListLog.Invoke((Action)(() => this.ListLog.AppendText(table + " Completed." + Environment.NewLine)));
                        ListLog.Invoke((Action)(() => this.ListLog.Focus()));

                        // Close con and Commit Trans
                        trans.Commit();
                        if (cn != null && cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }

                    isRunning = false;
                    progressBar1.Invoke((Action)(() => this.progressBar1.Value = maxProgress));
                    RetrievingTables.Invoke((Action)(() => this.RetrievingTables.Visible = false));

                    ListLog.Invoke((Action)(() => this.ListLog.AppendText((queryToExecute.Count - 2) + " tables copied successfully." + Environment.NewLine)));
                    ListLog.Invoke((Action)(() => this.ListLog.Focus()));
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                trans.Rollback();
                this.ElapsedTime.Stop();
                this.ElapsedTime.Enabled = false;
                //CancelBtn.Invoke((Action)(() => this.CancelBtn.Visible = false));
                progressBar1.Invoke((Action)(() => this.progressBar1.Value = 0));
                RetrievingTables.Invoke((Action)(() => this.RetrievingTables.Visible = false));

                // Append to Log
                ListLog.Invoke((Action)(() => this.ListLog.AppendText("Execution aborted." + Environment.NewLine)));
                ListLog.Invoke((Action)(() => this.ListLog.Focus()));

                MessageBox.Show("Sorry, There was an error encountered, the error was on the " + errorMsg + " table." + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// Handles the 1 event of the SelectAllTables_CheckedChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SelectAllTables_CheckedChanged_1(object sender, EventArgs e)
        {
            if (SelectAllTables.Checked)
            {
                for (int i = 0; i < TablesListbox.Items.Count; i++)
                {
                    TablesListbox.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < TablesListbox.Items.Count; i++)
                {
                    TablesListbox.SetItemChecked(i, false);
                }
            }

            this.SelectedLabel.Text = TablesListbox.CheckedItems.Count + " of " + tables_insert.Count + " selected";
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the backgroundWorker2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.backgroundWorker4.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the DoWork event of the backgroundWorker4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            this.GetMysqlDBConnection_Execute();
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the backgroundWorker4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Invoke((Action)(() => this.progressBar1.Value = 0));
            this.ElapsedTime.Stop();
            this.RetrievingTables.Visible = false;
            //this.CancelBtn.Visible = false;
            if (!hasErrors)
            {
                MessageBox.Show("Process completed successfully.");
            }
        }

        /// <summary>
        /// Handles the Tick event of the ElapsedTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ElapsedTime_Tick(object sender, EventArgs e)
        {
            totalSeconds++;
            if (totalSeconds > 0)
            {
                int tSec = totalSeconds;
                int sSec = tSec % 60;
                int minute = tSec / 60;
                int tMinute = minute % 60;
                int hour = minute / 60;
                int tHour = hour % 12;
                this.TimeTaken_Execute.Text = "Elapsed time " + tHour.ToString() + " : " + tMinute.ToString() + " : " + sSec.ToString();
            }
        }

        /// <summary>
        /// Displays the source and dest.
        /// </summary>
        private void DisplaySourceAndDest(string source, string dest)
        {
            string[] delimiter = { "=", ";" };

            // Source label
            string[] sql = source.Split(delimiter, StringSplitOptions.None);
            this.SourceLabel_Value.Text = GetFormattedSourceAndDest(sql);
            this.SourceLabel1.Text = GetFormattedSourceAndDest(sql);

            // Destination label
            sql = dest.Split(delimiter, StringSplitOptions.None);
            this.DestLabel_Value.Text = GetFormattedSourceAndDest(sql);
            this.DestLabel1.Text = GetFormattedSourceAndDest(sql);
        }

        /// <summary>
        /// Gets the formatted source and dest.
        /// </summary>
        /// <param name="mssql">The MSSQL.</param>
        /// <param name="?">The ?.</param>
        /// <returns></returns>
        private string GetFormattedSourceAndDest(string[] sql)
        {
            string formattedString = string.Empty;
            bool isSourceFirst = false, isDbFirst = false;

            for (int i = 0; i < sql.Length; i++)
            {
                if (sql[i].ToString().Trim().ToLower() == "data source" || sql[i].ToString().Trim().ToLower() == "source")
                {
                    if (isDbFirst)
                    {
                        formattedString = sql[i + 1] + formattedString;
                    }
                    else
                    {
                        formattedString += sql[i + 1] + "//";
                        isSourceFirst = true;
                    }
                }

                if (sql[i].ToString().Trim().ToLower() == "database" || sql[i].ToString().Trim().ToLower() == "db")
                {
                    if (isSourceFirst)
                    {
                        formattedString += sql[i + 1];
                    }
                    else
                    {
                        formattedString = "//" + sql[i + 1];
                        isDbFirst = true;
                    }
                }
            }

            return formattedString;
        }

        /// <summary>
        /// Handles the Click event of the BackBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                this.panel3.Visible = true;
                this.panel3.Enabled = false;
                this.LogPanel.Visible = false;
                //this.CancelBtn.Visible = true;
                this.RetrievingTables.SendToBack();
                this.RetrievingTables.Visible = false;
                this.ViewLogBtn.Visible = true;
            }
            else
            {
                InitializeDataExport();
            }
        }

        /// <summary>
        /// Handles the Click event of the ViewLogBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ViewLogBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                this.panel3.Visible = false;
                this.panel3.Enabled = true;
                this.LogPanel.Visible = true;
                //this.CancelBtn.Visible = true;
                this.RetrievingTables.Visible = true;
                this.RetrievingTables.BringToFront();
                this.ViewLogBtn.Visible = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                if (trans != null)
                {
                    //trans.Rollback();
                }

                cn.Close();
            }
        }

        /// <summary>
        /// Handles the ItemCheck event of the TablesListbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        private void TablesListbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                int c = TablesListbox.CheckedItems.Count + 1;
                this.SelectedLabel.Text = c + " of " + tables_insert.Count + " selected";
            }
            else
            {
                int c = TablesListbox.CheckedItems.Count - 1;
                this.SelectedLabel.Text = c + " of " + tables_insert.Count + " selected";
            }
        }

        /// <summary>
        /// Handles the Click event of the MatchBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MatchBtn_Click(object sender, EventArgs e)
        {
            if (MySQLTablesListBox != null && MySQLTablesListBox.Items != null && MySQLTablesListBox.Items.Count > 0)
            {
                for (int i = 0; i < TablesListbox.Items.Count; i++)
                {
                    TablesListbox.SetItemChecked(i, false);
                }

                var lob = (IList)this.Invoke(new Func<IList>(() => MySQLTablesListBox.Items.Cast<object>().ToList()));
                foreach (string item in lob)
                {
                    for (int i = 0; i < TablesListbox.Items.Count; i++)
                    {
                        if (TablesListbox.GetItemText(TablesListbox.Items[i]).Trim().ToLower() == item.Trim().ToLower())
                        {
                            TablesListbox.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ConnectionString for Cleanup
        /// </summary>
        public string connectionString_Cleanup;

        /// <summary>
        /// tables_insert
        /// </summary>
        Dictionary<string, string> tables_insert;

        /// <summary>
        /// tables_fields
        /// </summary>
        Dictionary<string, string> tables_fields;

        /// <summary>
        /// tables_mysql_db
        /// </summary>
        List<string> tables_mysql_db;

        /// <summary>
        /// connectionString_MSSQL_Export
        /// </summary>
        public string connectionString_MSSQL_Export;

        /// <summary>
        /// connectionString_MYSQL_Export
        /// </summary>
        public string connectionString_MYSQL_Export;

        /// <summary>
        /// QueryToExecute
        /// </summary>
        public Dictionary<string, StringBuilder> queryToExecute;

        /// <summary>
        /// hasErrors
        /// </summary>
        private bool hasErrors;

        /// <summary>
        /// maxProgress
        /// </summary>
        private int maxProgress;

        /// <summary>
        /// total Seconds
        /// </summary>
        private int totalSeconds = 1;

        /// <summary>
        /// isRunning
        /// </summary>
        private bool isRunning;

        /// <summary>
        /// 
        /// </summary>
        private bool isCheckedFromCodeBehind;

        #endregion
    }
}