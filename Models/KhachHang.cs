using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace de1.Models
{
    public class KhachHang
    {
        public string MaKH {get;set;}
        public string HoTenKH {get;set;}
        public string DiaChi {get;set;}
        public string DienThoai {get;set;}

        public KhachHang(){}
        public KhachHang(string MaKH, string HoTenKH, string DiaChi, string DienThoai){
            this.MaKH = MaKH;
            this.HoTenKH = HoTenKH;
            this.DiaChi = DiaChi;
            this.DienThoai = DienThoai;
        }
    }
}