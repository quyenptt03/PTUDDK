using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public ArrayList DanhSachSV;
        public ArrayList NewDSSV;
        public QuanLySinhVien()
        {
            DanhSachSV = new ArrayList();
        }

        public void Them(SinhVien sv)
        {
            this.DanhSachSV.Add(sv);
        }
        public SinhVien this[int index]
        {
            get
            {
                return (SinhVien)DanhSachSV[index];
            }
            set
            {
                DanhSachSV[index] = value;
            }
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in DanhSachSV)
                if (ss(obj, sv) == 0)
                {
                    svresult = sv;
                    break;
                }
            return svresult;
        }
        public bool Sua(SinhVien svSua, object obj, SoSanh ss)
        {
            bool kq = false;
            for (int i = 0; i < DanhSachSV.Count; i++)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svSua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = DanhSachSV.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj, DanhSachSV[i]) == 0)
                {
                    DanhSachSV.RemoveAt(i);
                }
            }
        }

        public void DocTuFile(string filename)
        {
            this.DanhSachSV = new ArrayList();
            string t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();
                sv.MSSV = s[0];
                sv.HoTen = s[1];
                sv.Phai = false;
                if (s[2] == "Nam")
                    sv.Phai = true;
                sv.NgaySinh = DateTime.Parse(s[3]);
                sv.Lop = s[4];
                sv.SoDT = s[5];
                sv.Email = s[6];
                sv.DiaChi= s[7];
                sv.Hinh = s[8];
                this.Them(sv);
            }
            sr.Close();
        }
    }
}
