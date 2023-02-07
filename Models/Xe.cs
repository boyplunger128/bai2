using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace de1.Models
{
    public class Xe
    {
        public string SoXe{get;set;}
        public string HangXe{get;set;}
        public string NamSX{get;set;}
        public string MaKH{get;set;}

        public Xe(){}

        public Xe(string SoXe, string HangXe, string NamSX, string MaKH){
            this.SoXe = SoXe;
            this.HangXe=HangXe;
            this.NamSX=NamSX;
            this.MaKH=MaKH;
        }
    }
}