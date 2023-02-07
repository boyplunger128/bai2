using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace de1.Models
{
    public class BaoDuong
    {
        public string MABD { get; set; }
        public DateTime NGAYNGIONHAN { get; set; }
        public DateTime NGAYGIOTRA { get; set; }
        public string SOKM { get; set; }
        public string NOIDUNG { get; set; }
        public string SOXE { get; set; }

        public BaoDuong(){}
        public BaoDuong(string MABD,DateTime NGAYNGIONHAN,DateTime NGAYGIOTRA, string soKm, string NOIDUNG){
            this.MABD = MABD;
            this.NGAYNGIONHAN = NGAYNGIONHAN;
            this.NGAYGIOTRA = NGAYGIOTRA;
            this.SOKM = soKm;
            this.NOIDUNG = NOIDUNG;
        }

        public BaoDuong(string MABD, DateTime NGAYNGIONHAN, DateTime NGAYGIOTRA, string SOKM, string NOIDUNG, string SOXE)
        {
            this.MABD = MABD;
            this.NGAYNGIONHAN = NGAYNGIONHAN;
            this.NGAYGIOTRA = NGAYGIOTRA;
            this.SOKM = SOKM;
            this.NOIDUNG = NOIDUNG;
            this.SOXE = SOXE;
        }


    }
}