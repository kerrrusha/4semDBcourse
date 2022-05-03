#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScienticPedagogicalWorkersRating.Data;
using ScienticPedagogicalWorkersRating.Models;

namespace ScienticPedagogicalWorkersRating.Controllers
{
    public class WorkTypesController : Controller
    {
        private readonly ScienticPedagogicalWorkersRatingContext _context;

        public WorkTypesController(ScienticPedagogicalWorkersRatingContext context)
        {
            _context = context;
        }

        // GET: WorkTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Work_Type.ToListAsync());
        }

        // GET: WorkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workType = await _context.Work_Type
                .FirstOrDefaultAsync(m => m.id == id);
            if (workType == null)
            {
                return NotFound();
            }

            return View(workType);
        }

        // GET: WorkTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,mark")] Work_Type workType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workType);
        }

        // GET: WorkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workType = await _context.Work_Type.FindAsync(id);
            if (workType == null)
            {
                return NotFound();
            }
            return View(workType);
        }

        // POST: WorkTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,mark")] Work_Type workType)
        {
            if (id != workType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkTypeExists(workType.id))
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
            return View(workType);
        }

        // GET: WorkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workType = await _context.Work_Type
                .FirstOrDefaultAsync(m => m.id == id);
            if (workType == null)
            {
                return NotFound();
            }

            return View(workType);
        }

        // POST: WorkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workType = await _context.Work_Type.FindAsync(id);
            _context.Work_Type.Remove(workType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkTypeExists(int id)
        {
            return _context.Work_Type.Any(e => e.id == id);
        }
    }
}
