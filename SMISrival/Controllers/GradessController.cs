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
    [Authorize]
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
            return Json(new { data = await _db.CreateGrades.ToListAsync() });
        }
        #endregion

    }
}