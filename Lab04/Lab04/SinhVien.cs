using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public bool Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Hinh {get; set;}

        public SinhVien(){}
        public SinhVien(string mssv, string hoten, bool phai, DateTime ns, string lop, string sodt, string email, string diachi, string hinh){
            this.MSSV = mssv;
            this.HoTen = hoten;
            this.Phai = phai;
            this.NgaySinh = ns;
            this.Lop = lop;
            this.SoDT = sodt;
            this.Email = email;
            this.DiaChi = diachi;
            this.Hinh = hinh;
        }
    }
}
