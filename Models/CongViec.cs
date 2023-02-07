using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace de1.Models
{
    public class CongViec
    {
        public string MaCV {get;set;}
        public string TenCV {get;set;}
        public string DonGia{get;set;}

        //constructor without params
        public CongViec(){}
        public CongViec(string MaCV, string TenCV, string DonGia){
            this.MaCV = MaCV;
            this.TenCV = TenCV;
            this.DonGia = DonGia;
        }
        
    }
}