using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {

            // lấy thông tin trong bảng sp và bao gồm thông tin thể loại
            IEnumerable<SanPham> sanPhams = _db.sanPhams.Include("TheLoai").ToList();
            return View(sanPhams);
        }
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Upsert(int Id)
        {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dsTheLoai = _db.theLoais.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });
            ViewBag.DSTheLoai = dsTheLoai;
            if (Id == 0) // Create /Insert
            {
                return View(sanpham);
            }
            else
            // edit / update
            {
                sanpham = _db.sanPhams.Include("TheLoai").FirstOrDefault(sp => sp.Id == Id);
                return View(sanpham);
            }

        }

        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                // thêm thông tin sanpham
                if (sanpham.Id == 0)
                {
                    _db.sanPhams.Add(sanpham);

                }
                else
                {
                    _db.sanPhams.Update(sanpham);
                }

                // lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.sanPhams.FirstOrDefault(sp => sp.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.sanPhams.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}

