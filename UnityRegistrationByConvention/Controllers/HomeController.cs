﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace UnityRegistrationByConvention.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(
			ICoreUserService userService, // CoreUserService should be registered
			ICoreLoginService loginService) // UkLoginService should be registered
		{
		}

		public ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
