using Klienci.Data;
using CsvHelper;
using CsvHelper.Configuration;
using ClosedXML.Excel;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadanie5.Models;
using static Klienci.Data.Klienci;
using static Klienci.Data.KlienciDataContext;
namespace Zadanie5.Controllers
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
            var klienci = _context.Klijentella.OrderBy(k => k.Id).ToList();

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
                        PESEL = kli.PESEL,
                        BirthYear = kli.BirthYear
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

        [HttpGet]
		public ActionResult Create()
		{
            return View();
		}


		[HttpPost]
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
                    TempData["successMessage"] = "Klient stworzony poprawnie";
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
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            try
            {
				var klient = _context.Klijentella.SingleOrDefault(x => x.Id == Id);
				if (klient != null)
				{
					var klienciView = new KlienciViewModel()
					{
						Id = klient.Id,
						Name = klient.Name,
						Surname = klient.Surname,
						PESEL = klient.PESEL,
						Plec = klient.Plec
					};
					return View(klienciView);
				}
				else
				{
					TempData["errorMessage"] = $"dane klienta nie związane z Id: {Id}";
					return RedirectToAction("Index");

				}
			}
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");

            }

        }

        // POST: test/Edit/5
        [HttpPost]
        public ActionResult Edit(KlienciViewModel model)
        {
            try
            {
				if (ModelState.IsValid)
				{
					var klient = new Klienci.Data.Klienci()
					{
						Id = model.Id,
						Name = model.Name,
						Surname = model.Surname,
						BirthYear = model.BirthYear,
						PESEL = model.PESEL,
						Plec = model.Plec
					};
					_context.Klijentella.Update(klient);
					_context.SaveChanges();
					TempData["successMessage"] = "Klient edytowany pomyślnie";
					return RedirectToAction("Index");
				}
				else
				{
                    TempData["errorMessage"] = "Błąd!";
                    return View();
	            }



			}
            catch(Exception ex)
            {
				TempData["errorMessage"] = ex.Message;
				return View("Index");
			}
           
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                var klient = _context.Klijentella.SingleOrDefault(x => x.Id == Id);
                if (klient != null)
                {
                    var klienciView = new KlienciViewModel()
                    {
                        Id = klient.Id,
                        Name = klient.Name,
                        Surname = klient.Surname,
                        PESEL = klient.PESEL,
                        Plec = klient.Plec
                    };
                    return View(klienciView);
                }
                else
                {
                    TempData["errorMessage"] = $"dane klienta nie związane z Id: {Id}";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");

            }

        }
        [HttpPost]
        public IActionResult Delete(KlienciViewModel model)
        {
            try
            {
				var klient = _context.Klijentella.SingleOrDefault(x => x.Id == model.Id);

				if (klient != null)
				{
					_context.Klijentella.Remove(klient);
					_context.SaveChanges();
					TempData["successMessage"] = "klient usunięty pomyślnie";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["errorMessage"] = $"dane klienta nie związane z Id: {model.Id}";
					return RedirectToAction("Index");

				}


			}
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

            }

			
		}

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["errorMessage"] = "Wybierz plik CSV lub XLSX.";
                return RedirectToAction("Import");
            }

            var ext = Path.GetExtension(file.FileName).ToLower();
            var klienci = new List<Klienci.Data.Klienci>();

            if (ext == ".csv")
            {
                using var stream = file.OpenReadStream();
                using var reader = new StreamReader(stream);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                });

                var records = csv.GetRecords<KlienciViewModel>();
                foreach (var vm in records)
                {
                    klienci.Add(new Klienci.Data.Klienci
                    {
                        Name = vm.Name,
                        Surname = vm.Surname,
                        PESEL = vm.PESEL,
                        Plec = vm.Plec,
                        BirthYear = vm.BirthYear
                    });
                }
            }
            else if (ext == ".xlsx")
            {
                using var stream = file.OpenReadStream();
                using var wb = new XLWorkbook(stream);
                var ws = wb.Worksheets.First();

                // odczyt nagłówków i ich numerów kolumn
                var header = ws.Row(1);
                int colName = header.Cells().First(c => c.GetString() == "Name").Address.ColumnNumber;
                int colSurname = header.Cells().First(c => c.GetString() == "Surname").Address.ColumnNumber;
                int colPesel = header.Cells().First(c => c.GetString() == "PESEL").Address.ColumnNumber;
                int colPlec = header.Cells().First(c => c.GetString() == "Plec").Address.ColumnNumber;
                int colBirthYear = header.Cells().First(c => c.GetString() == "BirthYear").Address.ColumnNumber;

                foreach (var row in ws.RowsUsed().Skip(1))
                {
                    string nameText = row.Cell(colName).GetString();
                    string surnameText = row.Cell(colSurname).GetString();
                    string peselText = row.Cell(colPesel).GetString();
                    string plecText = row.Cell(colPlec).GetString();
                    string yearText = row.Cell(colBirthYear).GetString();

                    if (!int.TryParse(plecText, out int plecValue))
                        continue;   // pomiń wiersz gdy płeć nie int
                    if (!int.TryParse(yearText, out int birthYearValue))
                        continue;   // pomiń wiersz gdy rok nie int

                    klienci.Add(new Klienci.Data.Klienci
                    {
                        Name = nameText,
                        Surname = surnameText,
                        PESEL = peselText,
                        Plec = plecValue,
                        BirthYear = birthYearValue
                    });
                }
            }
            else
            {
                TempData["errorMessage"] = "Nieobsługiwany format pliku.";
                return RedirectToAction("Import");
            }

            if (klienci.Any())
            {
                _context.Klijentella.AddRange(klienci);
                await _context.SaveChangesAsync();
                TempData["successMessage"] = $"Zaimportowano {klienci.Count} rekordów.";
            }
            else
            {
                TempData["errorMessage"] = "Brak poprawnych wierszy do zaimportowania.";
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Export()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Export(string format)
        {
            // Pobierz dane raz
            var data = _context.Klijentella
                .Select(k => new KlienciViewModel
                {
                    Id = k.Id,
                    Name = k.Name,
                    Surname = k.Surname,
                    PESEL = k.PESEL,
                    Plec = k.Plec,
                    BirthYear = k.BirthYear
                })
                .ToList();

            if (format == "csv")
            {
                // *** GENERUJ CSV i zwróć bajty ***
                byte[] bytes;
                using (var mem = new MemoryStream())
                {
                    using (var writer = new StreamWriter(mem, leaveOpen: true))
                    using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true
                    }))
                    {
                        csv.WriteHeader<KlienciViewModel>();
                        csv.NextRecord();
                        csv.WriteRecords(data);
                    }
                    // konieczne, by writer wypchał wszystko do wewnętrznego bufora
                    // (choć using writer zrobi Flush przy dispose)
                    bytes = mem.ToArray();
                }

                var fileName = $"Klienci_{DateTime.Now:yyyyMMddHHmmss}.csv";
                return File(bytes, "text/csv", fileName);
            }
            else if (format == "xlsx")
            {
                // *** GENERUJ XLSX i zwróć bajty ***
                byte[] bytes;
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Klienci");
                    // nagłówki
                    var headers = new[] { "Id", "Name", "Surname", "PESEL", "Plec", "BirthYear" };
                    for (int c = 0; c < headers.Length; c++)
                        ws.Cell(1, c + 1).Value = headers[c];
                    // dane
                    for (int i = 0; i < data.Count; i++)
                    {
                        var row = i + 2;
                        ws.Cell(row, 1).Value = data[i].Id;
                        ws.Cell(row, 2).Value = data[i].Name;
                        ws.Cell(row, 3).Value = data[i].Surname;
                        ws.Cell(row, 4).Value = data[i].PESEL;
                        ws.Cell(row, 5).Value = data[i].Plec;
                        ws.Cell(row, 6).Value = data[i].BirthYear;
                    }

                    using (var mem = new MemoryStream())
                    {
                        wb.SaveAs(mem);
                        bytes = mem.ToArray();
                    }
                }

                var fileName = $"Klienci_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                return File(
                    bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileName
                );
            }
            else
            {
                TempData["errorMessage"] = "Nieobsługiwany format.";
                return RedirectToAction("Export");
            }
        }




    }
}

