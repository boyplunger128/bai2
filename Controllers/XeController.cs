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


    public class XeController : Controller
    {
        private readonly ILogger<XeController> _logger;

        public XeController(ILogger<XeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Bai1()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ThemXe(){
            string MaCV = Request.Form["MaCV"].ToString();
            string TenCV = Request.Form["TenCV"].ToString();
            string DonGia = Request.Form["DonGia"].ToString();

            DbContext context = new DbContext();

            int count = context.ThemCongViec(MaCV, TenCV, DonGia);
            if(count != 0 ){
                ViewData["Thongbao"]="Theem thanh cong!";
            }else{
                ViewData["Thongbao"]="Theem that bai!";
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