using Project.Data;
using Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            var theLoai = _db.theLoais.ToList();
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
                _db.theLoais.Add(theloai);
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
            var theloai = _db.theLoais.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {

                //thêm vào bảng Theloai
                _db.theLoais.Update(theloai);
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
            var theloai = _db.theLoais.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int Id)
        {
            var theloai = _db.theLoais.Find(Id);
            if (theloai == null)
            {
                return NotFound();
            }    
            _db.theLoais.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var theloai = _db.theLoais.Find(id);

            if (id == 0)
            {
                return NotFound();
            }

            return View(theloai);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                //sử dung LINQ để tìm kiếm
                var theLoai = _db.theLoais.
                    Where(tl => tl.Name.Contains(searchString)).ToList();

                ViewBag.SearchString = searchString;
                ViewBag.TheLoai = theLoai;
               
            }
            else
            {
                var theLoai = _db.theLoais.ToList();
                ViewBag.TheLoai = theLoai;
            }    
            return View("Index"); // SD lại view index
        }
    }
}
