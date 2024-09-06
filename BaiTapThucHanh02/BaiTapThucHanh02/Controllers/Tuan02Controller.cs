using BaiTapThucHanh02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucHanh02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()  
        {
            ViewBag.HoTen = "Nguyễn Trường Huy";
            ViewBag.MSSV = "0123456789";
            ViewBag.Nam = 2024;
            
            return View();

        }


    }
}
