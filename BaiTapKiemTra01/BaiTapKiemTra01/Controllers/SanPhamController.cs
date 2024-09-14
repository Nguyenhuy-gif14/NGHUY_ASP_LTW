using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BaiTap02()
        {
            // Giả sử có một sản phẩm với các thông tin sau:
            var sanPham = new SanPhamViewModel
            {
                TenSanPham = "Máy tính xách tay Dell",
                GiaBan = 15000000, 
                AnhMoTa = "Laptopdell.jpg"
            };
            return View(sanPham);
        }
    }
}
