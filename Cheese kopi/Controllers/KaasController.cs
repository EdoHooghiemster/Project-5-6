using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cheese.Models;

namespace Cheese.Controllers
{
    public class KaasController : Controller
    {
        private readonly CheeseContext _context;

        public KaasController(CheeseContext context)
        {
            _context = context;
        }

        // GET: Kaas
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Kazen.ToListAsync());
        }
        public async Task<IActionResult> Aanbiedingen()
        {
            return View(await _context.Kazen.ToListAsync());
        }

        // GET: Kaas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaas = await _context.Kazen
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kaas == null)
            {
                return NotFound();
            }

            return View(kaas);
        }

        // GET: Kaas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kaas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Merk,Melksoort,Vet,Biologisch,Kaassoort,Eetbarekorst,Afkomst,Prijs,Afbeelding")] Kaas kaas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kaas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Admin));
            }
            return View(kaas);
        }

        // GET: Kaas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaas = await _context.Kazen.SingleOrDefaultAsync(m => m.Id == id);
            if (kaas == null)
            {
                return NotFound();
            }
            return View(kaas);
        }

        // POST: Kaas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Merk,Melksoort,Vet,Biologisch,Kaassoort,Eetbarekorst,Afkomst,Prijs,Afbeelding")] Kaas kaas)
        {
            if (id != kaas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kaas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KaasExists(kaas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Admin));
            }
            return View(kaas);
        }

        // GET: Kaas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaas = await _context.Kazen
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kaas == null)
            {
                return NotFound();
            }

            return View(kaas);
        }

        // POST: Kaas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kaas = await _context.Kazen.SingleOrDefaultAsync(m => m.Id == id);
            _context.Kazen.Remove(kaas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Admin));
        }

        private bool KaasExists(int id)
        {
            return _context.Kazen.Any(e => e.Id == id);
        }
    }
}