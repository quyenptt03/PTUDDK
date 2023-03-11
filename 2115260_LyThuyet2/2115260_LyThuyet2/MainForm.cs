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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void txtGroupbox_Click(object sender, EventArgs e)
        {
            var form = new frmGroupbox();
            form.ShowDialog();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            var form = new demoPanel();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new frmMenuStrip();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new frmStatusStrip();
            form.ShowDialog();
        }

        private void txtContextMenu_Click(object sender, EventArgs e)
        {
            var form = new frmContextMenu();
            form.ShowDialog();
        }

        private void btnImagList_Click(object sender, EventArgs e)
        {
            var form = new frmImageList();
            form.ShowDialog();
        }
    }
}
