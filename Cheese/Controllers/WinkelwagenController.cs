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
    public class WinkelwagenController : Controller
    {
        private readonly CheeseContext _context;

        public WinkelwagenController(CheeseContext context)
        {
            _context = context;
        }

        // GET: Kaas
        public async Task<IActionResult> Winkelwagen()
        {
            return View(await _context.Winkelwagens.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Soort,Aantal,Naam,Prijs")] Winkelwagen item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Winkelwagen));
            }
            return View(item);
        }

        // GET: Kaas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Winkelwagens.SingleOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Kaas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soort,Aantal,Naam,Prijs")] Winkelwagen item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!itemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Winkelwagen));
            }
            return View(item);
        }

        // GET: Kaas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Winkelwagens
                .SingleOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Kaas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kaas = await _context.Kazen.SingleOrDefaultAsync(m => m.Id == id);
            _context.Kazen.Remove(kaas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Winkelwagen));
        }

        private bool itemExists(int id)
        {
            return _context.Winkelwagens.Any(e => e.Id == id);
        }
    }
}
