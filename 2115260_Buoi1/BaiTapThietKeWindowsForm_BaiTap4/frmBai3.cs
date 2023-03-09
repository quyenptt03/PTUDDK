using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeWindowsForm_BaiTap4
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            string gt = "";
            int m = int.Parse(txtSoM.Text);
            int n = int.Parse(txtSoN.Text);
            if(rdNam.Checked)
            {
                gt = "Nam";
            } else if (rdNu.Checked)
            {
                gt = "Nữ";
            }
            if(rdChao.Checked)
            {
                lblKQ.Text = PhuongThuc.ChaoHoi(txtHoTen.Text, gt);
            } else if (rdUCLN.Checked)
            {
                lblKQ.Text = PhuongThuc.UCLN(m, n).ToString();
            }
        }
    }
}
