using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMISrival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Controllers
{
    public class GradessController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Grades Grades { get; set; }
        public GradessController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Grades = new Grades();
            if (id == null)
            {
                //create
                return View(Grades);
            }
            //update
            Grades = _db.Grades.FirstOrDefault(u => u.Id == id);
            if (Grades == null)
            {
                return NotFound();
            }
            return View(Grades);
        }

        public IActionResult Detail(int? id)
        {
            Grades = new Grades();
            if (id == null)
            {
                //create
                return View(Grades);
            }
            //update
            Grades = _db.Grades.FirstOrDefault(u => u.Id == id);
            if (Grades == null)
            {
                return NotFound();
            }
            return View(Grades);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Grades.Id == 0)
                {
                    //create
                    _db.Grades.Add(Grades);
                }
                else
                {
                    _db.Grades.Update(Grades);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Grades);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail()
        {
            if (ModelState.IsValid)
            {
                if (Grades.Id == 0)
                {
                    //create
                    _db.Grades.Add(Grades);
                }
                else
                {
                    _db.Grades.Update(Grades);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Grades);
        }



        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Grades.ToListAsync() });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var gradesFromDb = await _db.Grades.FirstOrDefaultAsync(u => u.Id == id);
            if (gradesFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Grades.Remove(gradesFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion

    }
}