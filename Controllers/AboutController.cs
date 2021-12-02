using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Entities;

namespace TravelTripProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        private TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

    }
}