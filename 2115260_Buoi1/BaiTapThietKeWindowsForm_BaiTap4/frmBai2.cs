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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void tbnXepLoai_Click(object sender, EventArgs e)
        {
            int diemLT = int.Parse(txtLyThuyet.Text);
            int diemTH = int.Parse(txtThucHanh.Text);
            float diemTB = (diemTH + diemLT) / 2;
            if (diemLT < 0 || diemLT > 10 || diemTH < 0 || diemTH > 10)
            {
                lblKQ.Text = "Điểm đã nhập không hợp lệ";
            }
            else if (diemLT < 5 || diemTH < 5)
                lblKQ.Text = "Yếu";
            else if (diemTB < 7)
                lblKQ.Text = "Trung bình";
            else if (diemTB >= 7 && diemTB < 8)
                lblKQ.Text = "Khá";
            else if (diemTB >= 8 && diemTB < 9)
                lblKQ.Text = "Giỏi";
            else if (diemTB >= 9)
                lblKQ.Text = "Xuất sắc";
        }
    }
}
