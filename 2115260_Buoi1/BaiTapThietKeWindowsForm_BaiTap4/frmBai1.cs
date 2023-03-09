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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.MaSanPham = "SP01";
            sp.TenSanPham = "Bàn phím SP01";
            sp.LoaiSanPham = "Bàn phím";
            sp.NgaySanXuat = new DateTime(2022, 5, 12);

            lblThongBao.Text = sp.HienThi();
        }
    }
}
