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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            int so1 = int.Parse(txtSo1.Text);
            int so2 = int.Parse(txtSo2.Text);
            int kq = 0;
            if(rdCong.Checked )
            {
                kq = so1 + so2;
            } else if(rdTru.Checked )
            {
                kq = so1 - so2;
            } else if(rdNhan.Checked )
            {
                kq = so1 * so2;
            } else
                kq = so1/ so2;

            lblKQ.Text = kq.ToString();
        }
    }
}
