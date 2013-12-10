using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCleanup
{
    public partial class ConnectionProp : Form
    {
        Cleanup dClean = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionProp"/> class.
        /// </summary>
        public ConnectionProp(Cleanup c)
        {
            InitializeComponent();
            this.dClean = c;
            if (!string.IsNullOrEmpty(this.dClean.connectionString_MSSQL_Export) && !string.IsNullOrEmpty(this.dClean.connectionString_MYSQL_Export))
            {
                this.MSSQL_CS.Text = this.dClean.connectionString_MSSQL_Export;
                this.MYSQL_CS.Text = this.dClean.connectionString_MYSQL_Export;
            }
        }

        /// <summary>
        /// Handles the Click event of the Save_CS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Save_CS_Click(object sender, EventArgs e)
        {
            dClean.SetConnectionstring_Export(this.MSSQL_CS.Text.Trim(), this.MYSQL_CS.Text.Trim());
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the label4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void label4_Click(object sender, EventArgs e)
        {
            dClean.SetConnectionstring_Export(this.MSSQL_CS.Text.Trim(), this.MYSQL_CS.Text.Trim());
            this.Close();
        }
    }
}
