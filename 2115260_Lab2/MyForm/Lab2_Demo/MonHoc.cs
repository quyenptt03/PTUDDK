using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Demo
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string TenMH { get; set; }
        public int SoTC { get; set; }
        public MonHoc()
        {

        }

        public MonHoc(string ten)
        {
            this.TenMH = ten;
        }
        public MonHoc(int id, string tenMH, int soTC)
        {
            this.Id = id;
            this.TenMH = tenMH;
            this.SoTC = soTC;
        }
        public override string ToString()
        {
            return TenMH;
        }
    }
}
