using Diary.Data;
using Diary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Diary.Controllers
{
    public class DiaryEntriesController : Controller
    {
        // field til ApplicationDbContext
        private readonly ApplicationDbContext _db;

        // ApplicationDbCOntext initializeres - Dette er dependency injection (opsat i Program.cs)
        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ - For at kunne hente data fra database og vise i view
        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();
            return View(objDiaryEntryList);
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create - Post - persister data til db. Data kommer fra Create.cshtml
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            // Validering 
            if(obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Server: Title too short");
            }

            // Hvis validering gennemføres gemmes objektet i databasen
            if(ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj);                     // Tilføjer objekt til db
                _db.SaveChanges();                            // Gemmer ændringerne i db
                return RedirectToAction("Index");   // Når data er gemt redirectes til index.cshtml
            }
            return View(obj);
        }

        // Edit(Update) - Get - her hentes obj udfra specifikt id
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // DiaryEntry objekt hentes fra databasen med passet Id, og gemmes i variabel
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            // Der tjekkes om objektet modtaget fra database er null 
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        // Edit(Update) - Post - her opdateres obj og gemmes i databasen
        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj);   // Opdatere entri i db
                _db.SaveChanges();              // Gemmer ændringer i db
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Delete - Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
            
        }

        // Delete - Post
        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {
            _db.DiaryEntries.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
