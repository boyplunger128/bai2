using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using de1.Models;

namespace de1.Controllers
{
   
    public class BaoDuongController : Controller
    {
        private readonly ILogger<BaoDuongController> _logger;

        public BaoDuongController(ILogger<BaoDuongController> logger)
        {
            _logger = logger;
        }

         public IActionResult Bai2(){
            return View();
        }

        [HttpPost]
        [HttpGet]
        public IActionResult TinhTrangCapNhat(string MaBD){
            DateTime NgayGioNhan = DateTime.Parse(Request.Form["NgayGioNhan"]);
            DateTime NgayGioTra = DateTime.Parse(Request.Form["NgayGioTra"]);
            string SoKM = Request.Form["SoKM"].ToString();
            string NoiDung = Request.Form["NoiDung"].ToString();    

            DbContext dbContext = new DbContext();

            int count = dbContext.CapNhat(new BaoDuong(MaBD, NgayGioNhan, NgayGioTra, SoKM, NoiDung));
            if(count!=0){
                ViewData["ThongBao"]="Cập nhật thành công";
            }else{
                ViewData["ThongBao"]="Cập nhật thất bại";
            }
            return View();
        }

        [HttpPost]
        public IActionResult LietKe(){
            string SoXe = Request.Form["SoXe"].ToString();

            DbContext context = new DbContext();
            List<BaoDuong> listBD = context.LietKe(SoXe);
            return View(listBD);
        }

        [HttpGet]
        public IActionResult Sua(string MaBD){
            DbContext context = new DbContext();

            BaoDuong bd = context.GetBaoDuong(MaBD);

            return View(bd);
        }



        [HttpGet]
        public IActionResult ChiTiet(string MABD){

            DbContext context = new DbContext();
        
            List<CongViec> listBD = context.ChiTiet(MABD);
            ViewBag.Model1 = listBD;
            ViewBag.Model2 = context.GetBaoDuong(MABD);
            int sum =0;
            foreach (CongViec cv in listBD){
                sum += Int32.Parse(cv.DonGia);
            }
            ViewBag.ThanhTien = sum;
            return View();

        }

        [HttpGet]
        public IActionResult Xoa(string MaCV,string MABD){
            DbContext context = new DbContext();
            Console.Write(MaCV);
            Console.Write(MABD);
            int count = context.XoaCV(MaCV,MABD);
            if(count !=0){
                ViewData["ThongBao"]="Xóa thành công";
            }else{
                ViewData["ThongBao"]="Xóa thất bại";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}