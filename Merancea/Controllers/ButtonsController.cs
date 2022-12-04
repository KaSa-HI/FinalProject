using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Merancea.Data;
using Merancea.Models;

namespace Merancea.Controllers
{
    public class ButtonsController : Controller
    {
        private readonly MeranceaContext _context;

        public ButtonsController(MeranceaContext context)
        {
            _context = context;
        }

        // GET: Buttons
        public async Task<IActionResult> Index()
        {
            var meranceaContext = _context.Buttons.Include(b => b.Page).Include(b => b.DestinationPage);
            return View(await meranceaContext.ToListAsync());
        }

        // GET: Buttons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buttons == null)
            {
                return NotFound();
            }

            var button = await _context.Buttons
                .Include(b => b.Page)
                .Include(b => b.DestinationPage)
                .FirstOrDefaultAsync(m => m.ButtonId == id);
            if (button == null)
            {
                return NotFound();
            }

            return View(button);
        }

        // GET: Buttons/Create
        public IActionResult Create()
        {
            ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Title");
            return View();
        }

        // POST: Buttons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ButtonId,Text,Attribute,PageId,DestinationPageId")] Button button)
        {
            if (ModelState.IsValid)
            {
                _context.Add(button);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Title", button.PageId);
            return View(button);
        }

        // GET: Buttons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buttons == null)
            {
                return NotFound();
            }

            var button = await _context.Buttons.FindAsync(id);
            if (button == null)
            {
                return NotFound();
            }
            ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Title", button.PageId);
            return View(button);
        }

        // POST: Buttons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ButtonId,Text,Attribute,PageId,DestinationPageId")] Button button)
        {
            if (id != button.ButtonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(button);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ButtonExists(button.ButtonId))
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
            ViewData["PageId"] = new SelectList(_context.Pages, "Id", "Title", button.PageId);
            return View(button);
        }

        // GET: Buttons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buttons == null)
            {
                return NotFound();
            }

            var button = await _context.Buttons
                .Include(b => b.Page)
                .FirstOrDefaultAsync(m => m.ButtonId == id);
            if (button == null)
            {
                return NotFound();
            }

            return View(button);
        }

        // POST: Buttons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buttons == null)
            {
                return Problem("Entity set 'MeranceaContext.Buttons'  is null.");
            }
            var button = await _context.Buttons.FindAsync(id);
            if (button != null)
            {
                _context.Buttons.Remove(button);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ButtonExists(int id)
        {
          return (_context.Buttons?.Any(e => e.ButtonId == id)).GetValueOrDefault();
        }
    }
}
