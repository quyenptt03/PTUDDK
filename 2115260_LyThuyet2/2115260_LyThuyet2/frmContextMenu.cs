using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2115260_LyThuyet2
{
    public partial class frmContextMenu : Form
    {
        public frmContextMenu()
        {
            InitializeComponent();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.lbNgoaiNgu.SelectedIndex;
            this.lbNgoaiNgu.Items.RemoveAt(i);
        }
    }
}
