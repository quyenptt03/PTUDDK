using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Lab3_Demo
{
    public partial class frmTuyChon : Form
    {
        int i;
        QuanLySinhVien qlsv;
        internal List<SinhVien> dssv = new List<SinhVien>();
        internal frmTuyChon(QuanLySinhVien _qlsv, int _i)
        {
            InitializeComponent();
            i = _i;
            qlsv = _qlsv;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTuyChon_Load(object sender, EventArgs e)
        {
            if (i == 0)
            {
                gbTim.Enabled = false;
            } else
            {
                btnSapXep.Enabled = false;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TuyChon tc = TuyChon.MaSV;
            string search = txtTim.Text;
            if (search == "")
            {
                MessageBox.Show("Hãy nhập thông tin tìm", "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdMaSV.Checked)
                {
                    tc = TuyChon.MaSV;
                }
                else if (rdHoten.Checked)
                {
                    tc = TuyChon.HoTen;
                }
                else if (rdNgaySinh.Checked)
                {
                    tc = TuyChon.NgaySinh;
                }

                dssv = qlsv.TimKiem_TheoTuyChon(search, tc);


                if (dssv == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên", "Kết quả tìm", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Số sinh viên tìm thấy: " + dssv.Count, "Kết quả tìm", MessageBoxButtons.OK);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (rdMaSV.Checked)
            {
                qlsv.SapXep_Loai(SoSanhTheoMaSV);
            }
            else if (rdHoten.Checked)
            {
                qlsv.SapXep_Loai(SoSanhTheoHoTen);
            }
            else if (rdNgaySinh.Checked)
            {
            }
            DialogResult = DialogResult.OK;
        }

        private int SoSanhTheoMaSV(object obj1, object obj2)
        {
            SinhVien sv1 = obj1 as SinhVien;
            SinhVien sv2 = obj2 as SinhVien;
            return sv1.MaSo.CompareTo(sv2.MaSo);
        }
        private int SoSanhTheoHoTen(object obj1, object obj2)
        {
            SinhVien sv1 = obj1 as SinhVien;
            SinhVien sv2 = obj2 as SinhVien;
            return sv1.HoTen.CompareTo(sv2.HoTen);
        }
        private int SoSanhTheoNgaySinh(object obj1, object obj2)
        {
            SinhVien sv1 = obj1 as SinhVien;
            SinhVien sv2 = obj2 as SinhVien;
            return sv1.NgaySinh.CompareTo(sv2.NgaySinh);
        }
    }
}
