﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMISrival.Controllers
{
    public class GradessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
