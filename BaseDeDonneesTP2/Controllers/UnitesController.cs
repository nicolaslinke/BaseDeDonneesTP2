using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaseDeDonneesTP2.Data;
using BaseDeDonneesTP2.Models;

namespace BaseDeDonneesTP2.Controllers
{
    public class UnitesController : Controller
    {
        private readonly BaseDeDonnees_TP2Context _context;

        public UnitesController(BaseDeDonnees_TP2Context context)
        {
            _context = context;
        }

        // GET: Unites
        public async Task<IActionResult> Index()
        {
            var baseDeDonnees_TP2Context = _context.Unites.Include(u => u.Faction);
            return View(await baseDeDonnees_TP2Context.ToListAsync());
        }

        // GET: Unites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unites == null)
            {
                return NotFound();
            }

            var unite = await _context.Unites
                .Include(u => u.Faction)
                .FirstOrDefaultAsync(m => m.UniteId == id);
            if (unite == null)
            {
                return NotFound();
            }

            return View(unite);
        }

        // GET: Unites/Create
        public IActionResult Create()
        {
            ViewData["FactionId"] = new SelectList(_context.Factions, "FactionId", "FactionId");
            return View();
        }

        // POST: Unites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniteId,FactionId,Nom,CoutEnPoint")] Unite unite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FactionId"] = new SelectList(_context.Factions, "FactionId", "FactionId", unite.FactionId);
            return View(unite);
        }

        // GET: Unites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unites == null)
            {
                return NotFound();
            }

            var unite = await _context.Unites.FindAsync(id);
            if (unite == null)
            {
                return NotFound();
            }
            ViewData["FactionId"] = new SelectList(_context.Factions, "FactionId", "FactionId", unite.FactionId);
            return View(unite);
        }

        // POST: Unites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniteId,FactionId,Nom,CoutEnPoint")] Unite unite)
        {
            if (id != unite.UniteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniteExists(unite.UniteId))
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
            ViewData["FactionId"] = new SelectList(_context.Factions, "FactionId", "FactionId", unite.FactionId);
            return View(unite);
        }

        // GET: Unites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unites == null)
            {
                return NotFound();
            }

            var unite = await _context.Unites
                .Include(u => u.Faction)
                .FirstOrDefaultAsync(m => m.UniteId == id);
            if (unite == null)
            {
                return NotFound();
            }

            return View(unite);
        }

        // POST: Unites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unites == null)
            {
                return Problem("Entity set 'BaseDeDonnees_TP2Context.Unites'  is null.");
            }
            var unite = await _context.Unites.FindAsync(id);
            if (unite != null)
            {
                _context.Unites.Remove(unite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniteExists(int id)
        {
          return (_context.Unites?.Any(e => e.UniteId == id)).GetValueOrDefault();
        }
    }
}
