using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapThietKeWindowsForm_BaiTap3
{
    internal class PhepToan
    {
        public static int Tong1N(int n)
        {
            int kq = 0;
            for(int i = 1; i <= n; i++)
            {
                kq += i;
            }
            return kq;
        }

        public static int GiaiThua(int n)
        {
            int kq = 1;
            for(int i =1; i <= n; i++)
            {
                kq *= i;
            }
            return kq;
        }

        public static void TachChuoi(string hoten, ref string s1, ref string s2 )
        {
            List<string> s = new List<string>(hoten.Split(new string[] { " " }, StringSplitOptions.None));
            s2 = s[s.Count - 1];
            for(int i = 0; i < s.Count - 1; i++)
            {
                s1 += s[i] + " ";
            }
        }

        public static bool ThuTu(int n1, int n2)
        {
            if (n2 == n1 + 1)
                return true;
            return false;
        }
    }
}
