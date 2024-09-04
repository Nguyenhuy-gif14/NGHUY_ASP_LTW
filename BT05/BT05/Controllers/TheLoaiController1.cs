using BT05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT05.Controllers
{
    public class TheLoaiController1 : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngày 28";
            ViewBag.Thang = "Thang 02";
            ViewData["Nam"] = "Năm 2030";
            return View();
        }
        public IActionResult Index2()
        {
            var theLoai = new TheLoaiViewModel
            {
                Id = 1,
                Name = "Trinh Tham"
            };
            return View(theLoai);
        }
    }
}
