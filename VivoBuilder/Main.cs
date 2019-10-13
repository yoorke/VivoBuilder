using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VivoBuilder
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void mnuConnectionCreateNewConnection_Click(object sender, EventArgs e)
        {
            Connect frmConnect = new Connect();
            frmConnect.ShowDialog();
        }

        private void mnuDatabaseLoadDatabaseTables_Click(object sender, EventArgs e)
        {
            ClassBuilder frmClassBuilder = new ClassBuilder();
            frmClassBuilder.MdiParent = this;
            frmClassBuilder.Show();
        }
    }
}
