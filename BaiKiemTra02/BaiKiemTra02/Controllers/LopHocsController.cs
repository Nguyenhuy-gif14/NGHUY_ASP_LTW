using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiKiemTra02.Data;
using BaiKiemTra02.Models;

namespace BaiKiemTra02.Controllers
{
    public class LopHocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LopHocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LopHocs
        public async Task<IActionResult> Index()
        {
              return _context.LopHocs != null ? 
                          View(await _context.LopHocs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LopHocs'  is null.");
        }

        // GET: LopHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LopHocs == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // GET: LopHocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LopHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }

        // GET: LopHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LopHocs == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHocs.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            return View(lopHoc);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenLopHoc,NamNhapHoc,NamRaTruong,SoLuongSinhVien")] LopHoc lopHoc)
        {
            if (id != lopHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocExists(lopHoc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }

        // GET: LopHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LopHocs == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // POST: LopHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LopHocs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LopHocs'  is null.");
            }
            var lopHoc = await _context.LopHocs.FindAsync(id);
            if (lopHoc != null)
            {
                _context.LopHocs.Remove(lopHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocExists(int id)
        {
          return (_context.LopHocs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
