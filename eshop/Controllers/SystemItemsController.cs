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
    public class SystemItemsController : Controller
    {
        private readonly eshopContext _context;

        public SystemItemsController(eshopContext context)
        {
            _context = context;
        }

        // GET: SystemItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemItem.ToListAsync());
        }

        // GET: SystemItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemItem = await _context.SystemItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemItem == null)
            {
                return NotFound();
            }

            return View(systemItem);
        }

        // GET: SystemItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Quantity,CostPice,SalePrice,MainImage,ItemCode,Status,ItemCategory,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] SystemItem systemItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemItem);
        }

        // GET: SystemItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemItem = await _context.SystemItem.FindAsync(id);
            if (systemItem == null)
            {
                return NotFound();
            }
            return View(systemItem);
        }

        // POST: SystemItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Quantity,CostPice,SalePrice,MainImage,ItemCode,Status,ItemCategory,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] SystemItem systemItem)
        {
            if (id != systemItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemItemExists(systemItem.Id))
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
            return View(systemItem);
        }

        // GET: SystemItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemItem = await _context.SystemItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemItem == null)
            {
                return NotFound();
            }

            return View(systemItem);
        }

        // POST: SystemItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemItem = await _context.SystemItem.FindAsync(id);
            _context.SystemItem.Remove(systemItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemItemExists(int id)
        {
            return _context.SystemItem.Any(e => e.Id == id);
        }
    }
}
