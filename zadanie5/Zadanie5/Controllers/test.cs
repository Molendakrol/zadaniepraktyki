using Klienci.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadanie5igopaw.Models;
using static Klienci.Data.Klienci;
using static Klienci.Data.KlienciDataContext;
namespace Zadanie5igopaw.Controllers
{
    public class test : Controller
    {
        private readonly KlienciDataContext _context;

        public test(KlienciDataContext context)
        {
            this._context = context;
        }

        // GET: test
        public ActionResult Index()
        {
            var klienci = _context.Klijentella.ToList();
			List<KlienciViewModel> listaklientow = new List<KlienciViewModel>();

			if (klienci != null)
            {   
                
                foreach(var kli in klienci)
                {
                    var KlienciViewModel = new KlienciViewModel()
                    {
                        Id = kli.Id,
                        Name = kli.Name,
                        Surname = kli.Surname,
                        Plec = kli.Plec,
                        PESEL = kli.PESEL
                    };

                    listaklientow.Add(KlienciViewModel);
				}
                return View(listaklientow);
            }
 
            return View(listaklientow);
        }

        // GET: test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(KlienciViewModel baza_klientow)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var klient = new Klienci.Data.Klienci()
                    {
                        Name = baza_klientow.Name,
                        Surname = baza_klientow.Surname,
                        PESEL = baza_klientow.PESEL,
                        Plec = baza_klientow.Plec,
                        BirthYear = baza_klientow.BirthYear

                    };

                    _context.Klijentella.Add(klient);
                    _context.SaveChanges();
                    TempData["success"] = "Kliend stworzony poprawnie";
                    return RedirectToAction("Index");

                }
                else
                {

                    TempData["errorMassage"] = "coś nie poszło";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMassage"] = ex.Message;
                return View();

            }
        }
     

        // GET: test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: test/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
    }
}
