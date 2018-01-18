using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cheese.Models;
using System.Net;
using System.Net.Mail;

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

        public IActionResult Activatie_scherm()
        {   
            return View();
        }
        public async Task<IActionResult> Accounts()
        {
            return View(await _context.Klanten.ToListAsync());
        }
        public async Task<IActionResult> AccountsEdit(int? id)
        {
            //return View(await _context.Kazen.ToListAsync());

            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Klanten.SingleOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AccountsEdit(int id, [Bind("Id,Voornaam,Achternaam,Geslacht,Geboortedatum,Email,Wachtwoord,Confirmwachtwoord,Telnummer,Huisnummer,Straatnaam,Postcode,Activatiecode,Geactiveerd")] Klant klant)
        {
            if (id != klant.Id)
            {
                return NotFound();
            }

            // if(ModelState.IsValid){
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
                return RedirectToAction(nameof(Accounts));
            // }
            // return View(klant);
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
                
                Guid activationCode = Guid.NewGuid();
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
                        confirmWachtwoord = klant.confirmWachtwoord,
                        Telnummer = klant.Telnummer,
                        Straatnaam = klant.Straatnaam, 
                        Huisnummer = klant.Huisnummer, 
                        Postcode = klant.Postcode, 
                        ActivatieCode = activationCode,
                        Geactiveerd = "Nee"
                      
                      
                    };

                SendActivationEmail(klant, activationCode);

                _context.Add(m);
                _context.SaveChanges();

                return RedirectToAction("Activatie_scherm");
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Voornaam,Achternaam,Geslacht,Geboortedatum,Email,Wachtwoord,confirmWachtwoord,Telnummer,Huisnummer,Straatnaam,Postcode,Geactiveerd")] Klant klant)
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
                    if (!KlantExists(klant.Id)  )
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
                    TempData["Straatnaam"] = usr.Straatnaam.ToString(); 
                    TempData["Huisnummer"] = usr.Huisnummer.ToString(); 
                    TempData["Postcode"] = usr.Postcode.ToString(); 
                    TempData["Geboortedatum"] = usr.Geboortedatum.ToString();
                    TempData["Geslacht"] = usr.Geslacht.ToString();
                    TempData["Telnummer"] = usr.Telnummer.ToString();
                    TempData["Geactiveerd"] = usr.Geactiveerd.ToString();
                  
                    TempData.Keep("Email");
                    TempData.Keep("Wachtwoord");
                    TempData.Keep("Id");
                    TempData.Keep("Geactiveerd");
                    
                    if(usr.Geactiveerd == "Ja")  
                    { 
                     
                             
                            return Redirect("Details/" + TempData["Id"]); 
                    } 
                    else 
                    { 
                            TempData.Remove("Email"); 
                            TempData.Remove("Id"); 
                            TempData.Remove("Voornaam"); 
                            TempData.Remove("Wachtwoord"); 
                            
                            RedirectToAction("Login"); 
                            ModelState.AddModelError("Email", "Username is fout of niet geactiveerd.");  
         
                    } 
                     
                
                }
             
                
            }
           ModelState.AddModelError("Email", "Onjuiste gegevens"); 
            return RedirectToAction("Login");
              
        }
      
        public IActionResult Favorieten()
        {
            return View();
        }
        public IActionResult Admin() 
        {
           
            if (TempData["Email"].ToString() == "mikekeehnen@me.com")
            {
                        return RedirectToAction("Admin","Kaas");
            }
            else
            {
                return Redirect("Details/" + TempData["Id"]);
            }
          
        }
        public IActionResult AdminAccountAanpassen() 
        {
           return RedirectToAction("Accounts");
            // if (TempData["Email"].ToString() == "mikekeehnen@me.com")
            // {
            //             
            // }
            // else
            // {
            //     return Redirect("Details/" + TempData["Id"]);
            // }
          
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

        // GET: Activation
        public IActionResult Activation()
        {
            ViewBag.Message = "Onjuiste activatiecode.";
            if (RouteData.Values["id"] != null)
            {
                Guid activationCode = new Guid(RouteData.Values["id"].ToString());
                Klant klant = _context.Klanten.SingleOrDefault(user => user.ActivatieCode == activationCode);
                if(klant != null){
                    if(klant.Geactiveerd == "Nee"){
                        klant.Geactiveerd = "Ja";
                        _context.SaveChanges();
                        ViewBag.Message = "Uw account is succesvol geactiveerd!";
                    }
                    else{
                        ViewBag.Message = "Uw account is al geactiveerd.";
                    }

                }
            }

            return View();
        }
        
        private void SendActivationEmail(Klant klant, Guid activationCode)
        {
            using (MailMessage mm = new MailMessage("cheesewitheasewebshop@gmail.com", klant.Email))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + klant.Voornaam + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + string.Format("http://cheesewithease.azurewebsites.net/Login/Activation/{0}", activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("cheesewitheasewebshop@gmail.com", "Cheesewithease");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
