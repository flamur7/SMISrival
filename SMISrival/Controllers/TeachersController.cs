using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMISrival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Teacher Teacher { get; set; }
        public TeachersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Teacher = new Teacher();
            if (id == null)
            {
                //create
                return View(Teacher);
            }
            //update
            Teacher = _db.Teachers.FirstOrDefault(u => u.Id == id);
            if (Teacher == null)
            {
                return NotFound();
            }
            return View(Teacher);
        }

        public IActionResult Detail(int? id)
        {
            Teacher = new Teacher();
            if (id == null)
            {
                //create
                return View(Teacher);
            }
            //update
            Teacher = _db.Teachers.FirstOrDefault(u => u.Id == id);
            if (Teacher == null)
            {
                return NotFound();
            }
            return View(Teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Teacher.Id == 0)
                {
                    //create
                    _db.Teachers.Add(Teacher);
                }
                else
                {
                    _db.Teachers.Update(Teacher);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail()
        {
            if (ModelState.IsValid)
            {
                if (Teacher.Id == 0)
                {
                    //create
                    _db.Teachers.Add(Teacher);
                }
                else
                {
                    _db.Teachers.Update(Teacher);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Teacher);
        }



        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Teachers.ToListAsync() });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var studentFromDb = await _db.Teachers.FirstOrDefaultAsync(u => u.Id == id);
            if (studentFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Teachers.Remove(studentFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}

