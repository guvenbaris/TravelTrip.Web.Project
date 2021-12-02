using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Entities;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogComment _blogComment = new BlogComment();
        private TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            //var bloglar = context.Blogs.ToList();
            _blogComment.Blogs = context.Blogs.ToList();
            _blogComment.TakeBlogs = context.Blogs.OrderByDescending(b => b.Id).Take(3).ToList();
            return View(_blogComment);
        }
       
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = context.Blogs.Where(b => b.Id == id).ToList();
            _blogComment.Blogs = context.Blogs.Where(x => x.Id == id).ToList();
            _blogComment.Comments = context.Comments.Where(c => c.Blogid == id).ToList();
            return View(_blogComment);
        }
        [HttpGet]
        public PartialViewResult DoComment(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult DoComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return PartialView();
        }
    }
}