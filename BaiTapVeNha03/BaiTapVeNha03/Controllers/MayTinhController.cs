using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha03.Controllers
{
    public class MayTinhController : Controller
    {
        public IActionResult MayTinh(double a, double b, string pheptinh)
        {
            double ketQua = 0;
            string error = null;

            switch (pheptinh?.ToLower())
            {
                case "cong":
                    ketQua = a + b;
                    break;
                case "tru":
                    ketQua = a - b;
                    break;
                case "nhan":
                    ketQua = a * b;
                    break;
                case "chia":
                    if (b != 0)
                        ketQua = a / b;
                    else
                        error = "Không thể chia cho 0";
                    break;
                default:
                    error = "Phép tính không hợp lệ";
                    break;
            }

            ViewBag.KetQua = ketQua;

            return View();
        }
        
    }
}
