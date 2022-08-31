using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caroline.Data;
using Caroline.Models;

namespace Caroline.Controllers
{
    public class SymbolController : Controller
    {
        private readonly SymbolContext _context;

        public SymbolController(SymbolContext context)
        {
            _context = context;
        }

        // GET: Symbol
        public async Task<IActionResult> Index()
        {
              return _context.Symbol != null ? 
                          View(await _context.Symbol.ToListAsync()) :
                          Problem("Entity set 'SymbolContext.Symbol'  is null.");
        }

        // GET: Symbol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Symbol == null)
            {
                return NotFound();
            }

            var symbol = await _context.Symbol
                .FirstOrDefaultAsync(m => m.Id == id);
            if (symbol == null)
            {
                return NotFound();
            }

            return View(symbol);
        }

        // GET: Symbol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Symbol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,English,Japanese")] Symbol symbol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(symbol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(symbol);
        }

        // GET: Symbol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Symbol == null)
            {
                return NotFound();
            }

            var symbol = await _context.Symbol.FindAsync(id);
            if (symbol == null)
            {
                return NotFound();
            }
            return View(symbol);
        }

        // POST: Symbol/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,English,Japanese")] Symbol symbol)
        {
            if (id != symbol.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(symbol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SymbolExists(symbol.Id))
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
            return View(symbol);
        }

        // GET: Symbol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Symbol == null)
            {
                return NotFound();
            }

            var symbol = await _context.Symbol
                .FirstOrDefaultAsync(m => m.Id == id);
            if (symbol == null)
            {
                return NotFound();
            }

            return View(symbol);
        }

        // POST: Symbol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Symbol == null)
            {
                return Problem("Entity set 'SymbolContext.Symbol'  is null.");
            }
            var symbol = await _context.Symbol.FindAsync(id);
            if (symbol != null)
            {
                _context.Symbol.Remove(symbol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomSymbol()
        {
            var random = new Random();
            var symbols = await _context.Symbol.ToListAsync();
            var randomIndex = random.Next(0, symbols.Count);
            var randomSymbol = symbols[randomIndex];
            return RedirectToAction("RandomIndex", "Home", randomSymbol);
        }

        private bool SymbolExists(int id)
        {
          return (_context.Symbol?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
