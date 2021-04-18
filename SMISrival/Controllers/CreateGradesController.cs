using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMISrival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CreateGradesController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public CreateGrade CreateGrade { get; set; }
        public CreateGradesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CreateGrade = new CreateGrade();
            if (id == null)
            {
                //create
                return View(CreateGrade);
            }
            //update
            CreateGrade = _db.CreateGrades.FirstOrDefault(u => u.Id == id);
            if (CreateGrade == null)
            {
                return NotFound();
            }
            return View(CreateGrade);
        }

        public IActionResult Detail(int? id)
        {
            CreateGrade = new CreateGrade();
            if (id == null)
            {
                //create
                return View(CreateGrade);
            }
            //update
            CreateGrade = _db.CreateGrades.FirstOrDefault(u => u.Id == id);
            if (CreateGrade == null)
            {
                return NotFound();
            }
            return View(CreateGrade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (CreateGrade.Id == 0)
                {
                    //create
                    _db.CreateGrades.Add(CreateGrade);
                }
                else
                {
                    _db.CreateGrades.Update(CreateGrade);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CreateGrade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail()
        {
            if (ModelState.IsValid)
            {
                if (CreateGrade.Id == 0)
                {
                    //create
                    _db.CreateGrades.Add(CreateGrade);
                }
                else
                {
                    _db.CreateGrades.Update(CreateGrade);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CreateGrade);
        }



        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.CreateGrades.ToListAsync() });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var creategradesFromDb = await _db.CreateGrades.FirstOrDefaultAsync(u => u.Id == id);
            if (creategradesFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.CreateGrades.Remove(creategradesFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion

    }
}
