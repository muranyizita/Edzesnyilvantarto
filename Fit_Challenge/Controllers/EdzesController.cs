using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fit_Challenge;
using Fit_Challenge.Adatdir;

namespace Fit_Challenge.Controllers
{
    public class EdzesController : Controller
    {
        private readonly AdatCTX _context;

        public EdzesController(AdatCTX context)
        {
            _context = context;
        }

        // GET: Edzes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Edzes.ToListAsync());
        }

        // GET: Edzes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Edzes == null)
            {
                return NotFound();
            }

            var edze = await _context.Edzes
                .FirstOrDefaultAsync(m => m.EdzesId == id);
            if (edze == null)
            {
                return NotFound();
            }

            return View(edze);
        }

        // GET: Edzes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Edzes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EdzesId,SportAg,SportFajta,Leiras,Datum,KezdIdopont,VegIdopont,ElvegzettE,ToroltE,KotelezoE")] Edze edze)
        {
            if (ModelState.IsValid)
            {
                edze.EdzesPerc = (int)(edze.VegIdopont.Value.Subtract(edze.KezdIdopont.Value).TotalMinutes);
                _context.Add(edze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edze);
        }

        // GET: Edzes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Edzes == null)
            {
                return NotFound();
            }

            var edze = await _context.Edzes.FindAsync(id);
            if (edze == null)
            {
                return NotFound();
            }
            return View(edze);
        }

        // POST: Edzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EdzesId,SportAg,SportFajta,Leiras,Datum,KezdIdopont,VegIdopont,ElvegzettE,ToroltE,KotelezoE,EdzesPerc")] Edze edze)
        {
            if (id != edze.EdzesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    edze.EdzesPerc = (int)(edze.VegIdopont.Value.Subtract(edze.KezdIdopont.Value).TotalMinutes);
                    _context.Update(edze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdzeExists(edze.EdzesId))
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
            return View(edze);
        }

        // GET: Edzes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Edzes == null)
            {
                return NotFound();
            }

            var edze = await _context.Edzes
                .FirstOrDefaultAsync(m => m.EdzesId == id);
            if (edze == null)
            {
                return NotFound();
            }
            return View(edze);
        }

        // POST: Edzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Edzes == null)
            {
                return Problem("Entity set 'AdatCTX.Edzes'  is null.");
            }
            var edze = await _context.Edzes.FirstOrDefaultAsync(p=>p.EdzesId==id);
            if (edze != null)
            {
                /*edze.ToroltE = true;
                _context.Edzes.Update(edze);*/
                _context.Edzes.Remove(edze);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Edzes/Edit/5
        public async Task<IActionResult> Delete2(int? id)
        {
            if (id == null || _context.Edzes == null)
            {
                return NotFound();
            }

            var edze = await _context.Edzes
                .FirstOrDefaultAsync(m => m.EdzesId == id);
            if (edze == null)
            {
                return NotFound();
            }
            return View(edze);
        }

        // POST: Edzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete2(int id, [Bind("EdzesId,SportAg,SportFajta,Leiras,Datum,KezdIdopont,VegIdopont,ElvegzettE,ToroltE,KotelezoE,EdzesPerc")] Edze edze)
        {
            if (id != edze.EdzesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    edze.EdzesPerc = (int)(edze.VegIdopont.Value.Subtract(edze.KezdIdopont.Value).TotalMinutes);
                    edze.ToroltE = true;
                    _context.Update(edze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdzeExists(edze.EdzesId))
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
            return View(edze);
        }

        public async Task<IActionResult> Today()
        {
            List<Edze> edzesek = await _context.Edzes.Where(e => ((DateTime)e.Datum).Date == DateTime.Today).ToListAsync();
            return View(edzesek);
        }


        public async Task<IActionResult> Deleted()
        {

            return View(await _context.Edzes.ToListAsync());
        }

        private bool EdzeExists(int id)
        {
          return _context.Edzes.Any(e => e.EdzesId == id);
        }



    }
}
