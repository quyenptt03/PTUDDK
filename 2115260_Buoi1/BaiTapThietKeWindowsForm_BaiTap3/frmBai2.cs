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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtSoN.Text);
            if(rdTong.Checked )
            {
                lblKQ.Text = PhepToan.Tong1N(n).ToString();
            }
            if(rdGiaiThua.Checked )
            {
                lblKQ.Text = PhepToan.GiaiThua(n).ToString();
            }
        }
    }
}
