using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapThietKeWindowsForm_BaiTap3
{
    internal class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int HeSoLuong { get; set; }
        public int HeSoPhuCap { get; set; }

        public NhanVien(string maNV, string hoTen, DateTime ngaySinh,int heSoLuong,int heSoPhuCap)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.HeSoLuong = heSoLuong;
            this.HeSoPhuCap = heSoPhuCap;
        }

        public int TongLuong()
        {
            return (HeSoPhuCap + HeSoLuong) * 1150000;
        }
        public string HienThi()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}", MaNV, HoTen, NgaySinh, HeSoLuong, HeSoPhuCap);
        }
    }
}
