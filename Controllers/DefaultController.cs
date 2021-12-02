using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Entities;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
           
            var values = context.Blogs.Take(8).ToList();
            return View(values);
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var values = context.Blogs.OrderByDescending(x => x.Id).Take(2).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial2()
        {
            var values = context.Blogs.Where(x => x.Id == 1).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial3()
        {
            var values = context.Blogs.Take(10).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial4()
        {
            var values = context.Blogs.Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial5()
        {
            var values = context.Blogs.Take(3).OrderByDescending(x => x.Id).ToList();
            return PartialView(values);
        }
    }
}