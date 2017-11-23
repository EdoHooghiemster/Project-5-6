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
    public class LoginController : Controller
    {
        private readonly CheeseContext _context;

        public IActionResult Layout()
        {
            return View();
        }
        public LoginController(CheeseContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: Login/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten
                .SingleOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult Create(Klant klant)
        {
            if (ModelState.IsValid)
            {

                if (_context.Klanten.Where(u => u.Email == klant.Email).Any())
                {
                    ModelState.AddModelError("Email","E-Mail al in gebruik");

                }
                else 
                {
                    var m = new Klant {
                        Id = klant.Id,
                        Voornaam = klant.Voornaam,
                        Achternaam = klant.Achternaam,
                        Geslacht = klant.Geslacht,
                        Geboortedatum = klant.Geboortedatum,
                        Email = klant.Email,
                        Wachtwoord = klant.Wachtwoord,
                        Telnummer = klant.Telnummer,
                        Adres = klant.Adres

                    };
                _context.Add(m);
                _context.SaveChanges();

                return RedirectToAction("Login");
                }

            }
            return View();
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten.SingleOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }
            return View(klant);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Voornaam,Achternaam,Geslacht,Geboortedatum,Email,Wachtwoord,Telnummer,Adres")] Klant klant)
        {
            if (id != klant.Id)
            { 
              
                return NotFound();
               
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(LoggedIn));
            }
            return View(klant);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten
                .SingleOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klant = await _context.Klanten.SingleOrDefaultAsync(m => m.Id == id);
            _context.Klanten.Remove(klant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

        private bool KlantExists(int id)
        {
            return _context.Klanten.Any(e => e.Id == id);
        }

         public IActionResult log()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult log(Klant login)
        {
            using (CheeseContext db = new CheeseContext())
            {
                var usr = _context.Klanten.Where(u => u.Email == login.Email && u.Wachtwoord == login.Wachtwoord).FirstOrDefault();            
                if (usr != null)
                {
                    TempData["Email"] = usr.Email.ToString();
                    TempData["Wachtwoord"] = usr.Wachtwoord.ToString();
                    TempData["Id"] = usr.Id.ToString();
                    TempData["Voornaam"] = usr.Voornaam.ToString();
                    TempData["Achternaam"] = usr.Achternaam.ToString();
                    TempData["Adres"] = usr.Adres.ToString();
                    TempData["Geboortedatum"] = usr.Geboortedatum.ToString();
                    TempData["Geslacht"] = usr.Geslacht.ToString();
                    TempData["Telnummer"] = usr.Telnummer.ToString();

                    TempData.Keep("Email");
                    TempData.Keep("Wachtwoord");
                    TempData.Keep("Id");
                    
                     return Redirect("Details/" + TempData["Id"]);
                    
                }
                else 
                {
                    ModelState.AddModelError("", "Username is fout.");
                
                }
                
            }
            return RedirectToAction("Login");
       
        }
      

        public IActionResult Admin() 
        {
           
            if (TempData["Email"].ToString() == "Admin@live.nl")
            {
                        return RedirectToAction("Admin","Kaas");
            }
            else
            {
                return Redirect("Details/" + TempData["Id"]);
            }
          
        }
        public IActionResult LoggedIn()
        {
            return Redirect("Details/" + TempData["Id"]);
        }

        public IActionResult LogUit()
        {
            TempData.Remove("Email");
            TempData.Remove("Id");
            TempData.Remove("Voornaam");
            TempData.Remove("Wachtwoord");
            return RedirectToAction("Login");
            
        }
        public IActionResult Profiel()
        {
            if (TempData["Voornaam"] != null)
            {
                return View();
                
            }   
            else
            {
                return RedirectToAction("Kaaspakketten");
            }
        }
    }
}
