using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Demo
{
    public class GiaoVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh;
        public DanhMucMonHoc dsMonHoc;
        public string GioiTinh;
        public string[] NgoaiNgu;
        public string SoDT;
        public string Mail;

        public GiaoVien()
        {
            dsMonHoc = new DanhMucMonHoc();
            NgoaiNgu = new string[10];
        }

        public GiaoVien(string maSo, string hoTen, DateTime ngaySinh, DanhMucMonHoc ds, string gt, string[] nn, string sdt, string mail)
        {
            this.MaSo = maSo;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.dsMonHoc = ds;
            this.GioiTinh = gt;
            this.NgoaiNgu = nn;
            this.SoDT = sdt;
            this.Mail = mail;
        }

        public override string ToString()
        {
            string s = "Mã số: " + MaSo + "\n"
                    + "Họ tên: " + HoTen + "\n"
                    + "Ngày sinh: " + NgaySinh.ToString() + "\n"
                    + "Giới tính: " + GioiTinh + "\n"
                    + "Số ĐT: " + SoDT + "\n"
                    + "Mail: " + Mail + "\n";
            string sNgoaiNgu = "Ngoại ngữ: ";
            foreach (string t in NgoaiNgu)
            {
                sNgoaiNgu += t + " ;";
            }
            string monDay = "Danh sách môn dạy: ";
            foreach (MonHoc md in dsMonHoc.ds)
            {
                monDay += md + ";";
            }
            s += "\n" + sNgoaiNgu +"\n" + monDay;
            return s;
        }
    }
}
