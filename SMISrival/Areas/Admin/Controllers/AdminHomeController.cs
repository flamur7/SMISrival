using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {


        private readonly RoleManager<IdentityRole> rolemanager;
        public AdminHomeController(RoleManager<IdentityRole> _roleManager)
        {
            rolemanager = _roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {

            if (!await rolemanager.RoleExistsAsync(roleName))
            {

                await rolemanager.CreateAsync(new IdentityRole(roleName));
            }

            return View();
        }
    }
}
