using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Demo
{
    internal class QuanLyGiaoVien
    {
        public enum KieuTim
        {
            TheoMa,
            TheoHoTen,
            TheoSoDT
        }
        public delegate int SoSanh(object a, object b);
        public List<GiaoVien> dsGiaoVien = new List<GiaoVien>();
        public GiaoVien this[int index]
        {
            get
            {
                return dsGiaoVien[index] as GiaoVien;
            }
            set
            {
                dsGiaoVien[index] = value;
            }
        }
        public QuanLyGiaoVien()
        {

        }
        public void SapXep(SoSanh ss)
        {
            for (int i = 0; i < dsGiaoVien.Count - 1; i++)
                for (int j = i + 1; j < dsGiaoVien.Count; j++)
                {
                    if (ss(dsGiaoVien[i], dsGiaoVien[j]) == 1)
                    {
                        GiaoVien t = dsGiaoVien[i];
                        dsGiaoVien[i] = dsGiaoVien[j];
                        dsGiaoVien[j] = t;
                    }
                }
        }

        public bool Them(GiaoVien gv)
        {
            bool kt = true;
            for(int i = 0; i < dsGiaoVien.Count; i++)
            {
                if (gv.MaSo == dsGiaoVien[i].MaSo)
                {
                    kt = false;
                    break;
                }
            }
            if (kt)
                dsGiaoVien.Add(gv);
            return kt;
        }

        public GiaoVien Tim(object temp, SoSanh ss)
        {
            GiaoVien result = new GiaoVien();
            temp = (GiaoVien)temp;
            KieuTim kt = KieuTim.TheoMa;
            for(int i = 0; i < dsGiaoVien.Count; i++)
            {
                switch (kt)
                {
                    case KieuTim.TheoMa:
                        return result;
                case KieuTim.TheoHoTen:
                        return result;
                    case KieuTim.TheoSoDT:
                        return result;
                }
            }
            return result;
        }
        public int TimTheoMaSo(object x, object y)
        {
            GiaoVien gv1 = (GiaoVien)x;
            GiaoVien gv2 = (GiaoVien)y;
            return gv1.MaSo.CompareTo(gv2.MaSo);
        }
        public int TimTheoHoTen(object x, object y)
        {
            GiaoVien gv1 = (GiaoVien)x;
            GiaoVien gv2 = (GiaoVien)y;
            return gv1.HoTen.CompareTo(gv2.HoTen);
        }
        public int TimTheoSoDT(object x, object y)
        {
            GiaoVien gv1 = (GiaoVien)x;
            GiaoVien gv2 = (GiaoVien)y;
            return gv1.SoDT.CompareTo(gv2.SoDT);
        }

        public void Xoa(object temp, SoSanh ss)
        {
            for (int i = 0; i < dsGiaoVien.Count; i++)
            {
                if (ss(dsGiaoVien[i], temp) == 1)
                {
                    dsGiaoVien.Remove(dsGiaoVien[i]);
                    break;
                }
            }
        }
    }
}
