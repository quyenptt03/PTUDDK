using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeWindowsForm_BaiTap3
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            int n1 = int.Parse(txtSoN1.Text);
            int n2 = int.Parse(txtSoN2.Text);
            string ho="", ten="";
            if(rdTachHoTen.Checked)
            {
                PhepToan.TachChuoi(txtHoTen.Text, ref ho, ref ten);
                lblKQ.Text = $"Họ: {ho}, tên: {ten}";
            }
            if(rdKTThuTu.Checked)
            {
                if (PhepToan.ThuTu(n1, n2))
                    lblKQ.Text = "Đúng";
                else
                    lblKQ.Text = "Sai";
            }
        }
    }
}
