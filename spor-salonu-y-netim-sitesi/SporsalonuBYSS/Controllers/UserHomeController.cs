﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporsalonuBYSS.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult UserHomePage()
        {
            return View();
        }
    }
}