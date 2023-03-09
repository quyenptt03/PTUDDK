using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapThietKeWindowsForm_BaiTap4
{
    internal class PhuongThuc
    {
        public static string ChaoHoi(string hoten, string gt)
        {
            string loiChao = "";
            if(gt =="Nam")
            {
                loiChao = $"Chào Ông {hoten}";
            } else if(gt == "Nữ")
            {
                loiChao = $"Chào Bà {hoten}";
            }
            return loiChao;
        }

        public static int UCLN(int m, int n)
        {
            while(m != n)
            {
                if (m > n)
                {
                    m = m - n;
                } else if(m < n)
                {
                    n = n - m;
                }
            }
            return m;
        }
    }
}
