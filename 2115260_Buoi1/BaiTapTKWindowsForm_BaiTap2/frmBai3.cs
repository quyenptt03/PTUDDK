using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTKWindowsForm_BaiTap2
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnXemKQ_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtSoN.Text);
            string hoten ="";
             
            if(rdGhepHoTen.Checked)
            {
                PhuongThuc.NoiChuoi(txtHo.Text, txtTen.Text, ref hoten);
                lblKQ.Text = hoten;
            } else if (rdGiaiThua.Checked)
            {
                lblKQ.Text = PhuongThuc.GiaiThua(n).ToString();
            }
        }
    }
}
