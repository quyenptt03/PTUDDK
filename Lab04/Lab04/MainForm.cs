using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class MainForm : Form
    {
        QuanLySinhVien qlsv;
        bool dsDaChinhSua = false;
        public MainForm()
        {
            InitializeComponent();
        }

        #region Phuong thuc bo tro
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool phai = true;
            sv.MSSV = this.mtbMSSV.Text;
            sv.HoTen = this.txtHoTen.Text;
            if (rdNu.Checked)
                phai = false;
            sv.Phai = phai;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cbbLop.Text;
            sv.SoDT = this.mtbSoDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Email = this.txtEmail.Text;
            sv.Hinh = this.txtHinh.Text;
            
            return sv;
        }

        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.Phai = false;
            if (lvitem.SubItems[2].Text=="Nam")
                sv.Phai = true;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoDT = lvitem.SubItems[5].Text;
            sv.Email = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.Hinh = lvitem.SubItems[8].Text;

            return sv;
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtbMSSV.Text = sv.MSSV;
            this.txtHoTen.Text = sv.HoTen;
            if (sv.Phai)
                this.rdNam.Checked = true;
            else this.rdNu.Checked = true;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cbbLop.Text = sv.Lop;
            this.mtbSoDT.Text = sv.SoDT;
            this.txtDiaChi.Text = sv.DiaChi;
            this.txtEmail.Text = sv.Email;
            this.txtHinh.Text = sv.Hinh;
            this.pbHinh.ImageLocation = sv.Hinh;

        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoTen);
            string phai = "Nữ";
            if (sv.Phai)
                phai = "Nam";
            lvitem.SubItems.Add(phai);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoDT);
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Email);
            lvitem.SubItems.Add(sv.Hinh);
            lvDSSV.Items.Add(lvitem);

        }
        private void LoadListView()
        {
            this.lvDSSV.Items.Clear();
            foreach (SinhVien sv in qlsv.DanhSachSV)
            {
                ThemSV(sv);
            }
        }
        #endregion
        #region su kien
        private void MainForm_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile("DSSV.txt");
            LoadListView();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(dsDaChinhSua)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu danh sách sinh viên đã thay đổi?", "Lưu danh sách", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    LuuVaoFile("DSSV.txt");
                }
            }

        }

        private void LuuVaoFile(string filename)
        {
            SinhVien sv;
            try { 
                using (StreamWriter sw  = new StreamWriter(filename))
                {
                    foreach (ListViewItem lvitem in lvDSSV.Items)
                    {
                        sv = GetSinhVienLV(lvitem);
                        string phai = "Nữ";
                        if (sv.Phai == true)
                            phai = "Nam";
                        sw.WriteLine($"{sv.MSSV}*{sv.HoTen}*{phai}*{sv.NgaySinh}*{sv.Lop}*{sv.SoDT}*{sv.Email}*{sv.DiaChi}*{sv.Hinh}*");
                    }
                }
            }
            catch(Exception ex) {
                DialogResult result = MessageBox.Show($"Xảy ra lỗi khi lưu file: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbHinh.Image = new Bitmap(open.FileName);
                txtHinh.Text = open.FileName;
            }  
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtbMSSV.Text = "";
            this.txtHoTen.Text = "";
            this.rdNam.Checked = true;
            this.dtpNgaySinh.Value = DateTime.Now;
            this.cbbLop.Text = this.cbbLop.Items[0].ToString();
            this.mtbSoDT.Text = "";
            this.txtEmail.Text = "";
            this.txtDiaChi.Text = ""; 
            this.pbHinh.ImageLocation = "";
            pbHinh.Image = null;
            this.txtHinh.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dsDaChinhSua = true;
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.MSSV,
            delegate(object obj1, object obj2)
            {
                return (obj2 as
                SinhVien).MSSV.CompareTo(obj1.ToString());
            });
            if (kq != null)
            {
                this.qlsv.Sua(sv, sv.MSSV, SoSanhTheoMa);
                LoadListView();
            }
            else
            {
                this.qlsv.Them(sv);
                LoadListView();
            }
            this.btnMacDinh.PerformClick();
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MSSV.CompareTo(obj1);
        }

        private void lvDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvDSSV.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvDSSV.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void xoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dsDaChinhSua = true;
            int count, i;
            ListViewItem lvitem;
            count = this.lvDSSV.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvDSSV.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView();
            this.btnMacDinh.PerformClick();
        }
        private void tảiLạiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            qlsv.DocTuFile("DSSV.txt");
            LoadListView();
        }

        #endregion

    }
}
