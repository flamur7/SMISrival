using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMISrival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Student Studnet { get; set; }
        public StudentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Studnet = new Student();
            if (id == null)
            {
                //create
                return View(Studnet);
            }
            //update
            Studnet = _db.Students.FirstOrDefault(u => u.Id == id);
            if (Studnet == null)
            {
                return NotFound();
            }
            return View(Studnet);
        }

        public IActionResult Detail(int? id)
        {
            Studnet = new Student();
            if (id == null)
            {
                //create
                return View(Studnet);
            }
            //update
            Studnet = _db.Students.FirstOrDefault(u => u.Id == id);
            if (Studnet == null)
            {
                return NotFound();
            }
            return View(Studnet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Studnet.Id == 0)
                {
                    //create
                    _db.Students.Add(Studnet);
                }
                else
                {
                    _db.Students.Update(Studnet);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Studnet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail()
        {
            if (ModelState.IsValid)
            {
                if (Studnet.Id == 0)
                {
                    //create
                    _db.Students.Add(Studnet);
                }
                else
                {
                    _db.Students.Update(Studnet);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Studnet);
        }



        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Students.ToListAsync() });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var studentFromDb = await _db.Students.FirstOrDefaultAsync(u => u.Id == id);
            if (studentFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Students.Remove(studentFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
