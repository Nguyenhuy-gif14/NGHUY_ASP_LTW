using BaiTap07.Data;
using BaiTap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap07.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            var theLoai = _db.TheLoais.ToList();
            ViewBag.theLoai = theLoai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Thread theloai)
        {
            //thêm vào nbangr Theloai
            _ = _db.TheLoais.Add(theloai);
            //lưu
            _db.SaveChanges();
            return View();
        }
    }
}
