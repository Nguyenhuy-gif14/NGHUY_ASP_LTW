using Microsoft.AspNetCore.Mvc;

namespace BaiTap04.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return Ok($"Id: {id}");
        }

        public IActionResult Detail(int id, string ten)
        {
            return Content($"id: {id}; ten: {ten}");
        }

        public IActionResult Show(List<string> categories)
        {
            string content = "Danh sách thể loại:";
            foreach (var category in categories)
            {
                content += " " + category;
            }
            return Content(content);
        }
    }
}
