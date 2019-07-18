using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eshop.Models;

namespace eshop.Controllers
{
    public class SystemCategoriesController : Controller
    {
        private readonly eshopContext _context;

        public SystemCategoriesController(eshopContext context)
        {
            _context = context;
        }

        // GET: SystemCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemCategory.ToListAsync());
        }

        // GET: SystemCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemCategory = await _context.SystemCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemCategory == null)
            {
                return NotFound();
            }

            return View(systemCategory);
        }

        // GET: SystemCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Picture,Status,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] SystemCategory systemCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemCategory);
        }

        // GET: SystemCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemCategory = await _context.SystemCategory.FindAsync(id);
            if (systemCategory == null)
            {
                return NotFound();
            }
            return View(systemCategory);
        }

        // POST: SystemCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Picture,Status,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] SystemCategory systemCategory)
        {
            if (id != systemCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemCategoryExists(systemCategory.Id))
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
            return View(systemCategory);
        }

        // GET: SystemCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemCategory = await _context.SystemCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemCategory == null)
            {
                return NotFound();
            }

            return View(systemCategory);
        }

        // POST: SystemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemCategory = await _context.SystemCategory.FindAsync(id);
            _context.SystemCategory.Remove(systemCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemCategoryExists(int id)
        {
            return _context.SystemCategory.Any(e => e.Id == id);
        }
    }
}
