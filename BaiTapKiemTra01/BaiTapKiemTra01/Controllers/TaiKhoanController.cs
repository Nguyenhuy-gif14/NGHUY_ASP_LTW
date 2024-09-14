using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hiển Thị Dữ Liệu Nhập Vào
                return Content($"Tên tài khoản: {model.TenTaiKhoan}, Họ tên: {model.HoTen}, Tuổi: {model.Tuoi}");
            }

            return View(model); //nếu có lỗi, quay lại form
        }
    }
}
