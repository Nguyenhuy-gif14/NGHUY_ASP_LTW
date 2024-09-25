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
        public IActionResult Create(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {

                //thêm vào nbangr Theloai
                _db.TheLoais.Add(theloai);
                //lưu
                _db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id== 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoais.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {

                //thêm vào bảng Theloai
                _db.TheLoais.Update(theloai);
                //lưu
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoais.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int Id)
        {
            var theloai = _db.TheLoais.Find(Id);
            if (theloai == null)
            {
                return NotFound();
            }    
            _db.TheLoais.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var theloai = _db.TheLoais.Find(id);

            if (theloai == null)
            {
                return NotFound();
            }

            return View(theloai);
        }

        [HttpPost]
        public IActionResult DetailsConfirm(int Id)
        {
            var theloai = _db.TheLoais.Find(Id);
            if (theloai == null)
            {
                return NotFound();
            }
            return RedirectToAction("Details", new {id = Id });
        }
    }
}
