using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaseDeDonneesTP2.Data;
using BaseDeDonneesTP2.Models;
using Microsoft.Data.SqlClient;
using BaseDeDonneesTP2.ViewModel;

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
            return View(await _context.VwAttributsDunites.OrderBy(x => x.NomDeFaction).ToListAsync());
            //var baseDeDonnees_TP2Context = _context.Unites.Include(u => u.Faction);
            //return View(await baseDeDonnees_TP2Context.ToListAsync());
        }

        // GET: Unites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unites == null)
            {
                return NotFound();
            }

           string query = "EXEC Unites.usp_dataSheet @UniteID";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@UniteID", Value = id}
            };
            List<VwDataSheet> dataSheet = await _context.VwDataSheets.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
            DataSheetVM dataSheetVM = new DataSheetVM();

            dataSheetVM.DataSheet = dataSheet;

            dataSheetVM.PhotoUnite = dataSheet
                                .Select(x => x.Photo == null ? null : $"data:image/png;base64, {Convert.ToBase64String(x.Photo)}")
                                .ToList();

            return View(dataSheetVM);
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

        public async Task<IActionResult> Abilite(int? id)
        {
            if (id == null || _context.Unites == null)
            {
                return NotFound();
            }
            List<AbiliteDunite> abiliteDunites = await _context.AbiliteDunites.Where(x => x.UniteId == id).ToListAsync();
            List<Abilite> abilites = new List<Abilite>();
            List<AbiliteDeChiffrerVM> abilitesDeChiffrer = new List<AbiliteDeChiffrerVM>();
            if (abiliteDunites != null)
            {
                foreach (var item in abiliteDunites)
                {
                    abilites.Add(_context.Abilites.Where(x => x.AbiliteId == item.AbiliteId).FirstOrDefault());
                }

                foreach (var item in abilites)
                {
                    string query = "EXEC Abilites.USP_DecryptDescription @AbiliteID";
                    SqlParameter parameter = new SqlParameter { ParameterName = "@AbiliteID", Value = item.AbiliteId };
                    Description? descriptionDeChiffrer = (await _context.Descriptions.FromSqlRaw(query, parameter).ToListAsync()).FirstOrDefault();

                    AbiliteDeChiffrerVM abiliteDeChiffrerVM = new AbiliteDeChiffrerVM();
                    abiliteDeChiffrerVM.DescriptionDeChiffrer = descriptionDeChiffrer;
                    abiliteDeChiffrerVM.Abilite = item;

                    abilitesDeChiffrer.Add(abiliteDeChiffrerVM);
                }
            }

            return View(abilitesDeChiffrer);
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
            ImageUploadVM imageUploadVM = new ImageUploadVM();
            imageUploadVM.Unite = unite;
            ViewData["FactionId"] = new SelectList(_context.Factions, "FactionId", "FactionId", unite.FactionId);
            return View(imageUploadVM);
        }

        // POST: Unites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ImageUploadVM imageVM)
        {
            if (id != imageVM.Unite.UniteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageVM.FormFile != null && imageVM.FormFile.Length >= 0)
                    {
                        MemoryStream stream = new MemoryStream();
                        await imageVM.FormFile.CopyToAsync(stream);
                        byte[] fichierImage = stream.ToArray();

                        imageVM.Unite.Photo = fichierImage;
                    }

                    try
                    {
                        _context.Update(imageVM.Unite);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UniteExists(imageVM.Unite.UniteId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    _context.Update(imageVM.Unite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniteExists(imageVM.Unite.UniteId))
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
            ViewData["FactionId"] = new SelectList(_context.Factions, "FactionId", "FactionId", imageVM.Unite.FactionId);
            return View(imageVM.Unite);
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
