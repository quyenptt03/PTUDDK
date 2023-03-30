using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Demo
{
    public delegate int SoSanh(object sv1, object sv2);
    enum TuyChon
    {
        MaSV,
        HoTen,
        NgaySinh
    }
    class QuanLySinhVien
    {
        public List<SinhVien> DanhSach;
        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }
        public void Them(SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get
            {
                return DanhSach[index];
            }
            set
            {
                DanhSach[index] = value;
            }
        }
        public void Xoa(object obj, SoSanh ss)
        {
            int i = DanhSach.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj, DanhSach[i]) == 0)
                {
                    DanhSach.RemoveAt(i);
                }
            }
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svResult = null;
            foreach (SinhVien sv in DanhSach)
            {
                if (ss(obj, sv) == 0)
                {
                    svResult = sv;
                    break;
                }
            }
            return svResult;
        }
        public bool Sua(SinhVien svSua, object obj, SoSanh ss)
        {
            bool kq = false;
            for (int i = 0; i < DanhSach.Count; i++)
            {
                if (ss(obj, DanhSach[i]) == 0)
                {
                    DanhSach[i] = svSua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }
        public void DocTuFile()
        {
            string filename = "DanhSachSV.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split(',');
                sv = new SinhVien();
                sv.MaSo = s[0];
                sv.HoTen = s[1];
                sv.NgaySinh = DateTime.ParseExact(s[2], "dd/MM/yyyy",CultureInfo.InvariantCulture);
                sv.DiaChi = s[3];
                sv.Lop = s[4];
                sv.Hinh = s[5];
                sv.GioiTinh = false;
                if (s[6] == "Nam")
                    sv.GioiTinh = true;
                string[] cn = s[7].Split(',');
                foreach (string c in cn)
                    sv.ChuyenNganh.Add(c);
                this.Them(sv); 
            }
        }

        public List<SinhVien> TimKiem_TheoTuyChon(string search, TuyChon tc)
        {
            List<SinhVien> dssv = new List<SinhVien>();
            if(tc == TuyChon.MaSV)
            {
                foreach(SinhVien sv in DanhSach)
                {
                    if(sv.MaSo.Contains(search))
                        dssv.Add(sv);
                }
            } else if (tc == TuyChon.HoTen)
            {
                foreach (SinhVien sv in DanhSach)
                {
                    if (sv.HoTen.ToLower().Contains(search.ToLower()))
                        dssv.Add(sv);
                }
            }
            else if (tc == TuyChon.NgaySinh)
            {
                foreach (SinhVien sv in DanhSach)
                {
                    if (sv.NgaySinh == DateTime.ParseExact(search, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        dssv.Add(sv);
                }
            }
            return dssv;
        }

        public void SapXep_Loai(SoSanh ss)
        {
            for(int i = 0; i < DanhSach.Count -1; i++)
            {
                for(int j = i+1; j < DanhSach.Count; j++)
                {
                    if (ss(DanhSach[i], DanhSach[j])== 1)
                    {
                        SinhVien temp = DanhSach[i];
                        DanhSach[i] = DanhSach[j];
                        DanhSach[j] = temp;
                    }
                }
            }
        }

    }

}
