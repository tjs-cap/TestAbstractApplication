using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAbstract.Data;
using TestAbstract.Models;

namespace TestAbstract.Controllers
{
    public class TestDsController : Controller
    {
        private readonly TestAbstractContext _context;

        public TestDsController(TestAbstractContext context)
        {
            _context = context;
        }

        // GET: TestDs
        public async Task<IActionResult> Index()
        {
              return _context.TestD != null ? 
                          View(await _context.TestD.ToListAsync()) :
                          Problem("Entity set 'TestAbstractContext.TestD'  is null.");
        }

        // GET: TestDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestD == null)
            {
                return NotFound();
            }

            var testD = await _context.TestD
                .FirstOrDefaultAsync(m => m.id == id);
            if (testD == null)
            {
                return NotFound();
            }

            return View(testD);
        }

        // GET: TestDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("workingIT,age,Description,id,name")] TestD testD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testD);
        }

        // GET: TestDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestD == null)
            {
                return NotFound();
            }

            var testD = await _context.TestD.FindAsync(id);
            if (testD == null)
            {
                return NotFound();
            }
            return View(testD);
        }

        // POST: TestDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("workingIT,age,Description,id,name")] TestD testD)
        {
            if (id != testD.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDExists(testD.id))
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
            return View(testD);
        }

        // GET: TestDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestD == null)
            {
                return NotFound();
            }

            var testD = await _context.TestD
                .FirstOrDefaultAsync(m => m.id == id);
            if (testD == null)
            {
                return NotFound();
            }

            return View(testD);
        }

        // POST: TestDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestD == null)
            {
                return Problem("Entity set 'TestAbstractContext.TestD'  is null.");
            }
            var testD = await _context.TestD.FindAsync(id);
            if (testD != null)
            {
                _context.TestD.Remove(testD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestDExists(int id)
        {
          return (_context.TestD?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
