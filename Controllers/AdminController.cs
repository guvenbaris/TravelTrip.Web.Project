using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TravelTripProject.Models.Entities;

namespace TravelTripProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            var values = context.Blogs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogDelete(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGet(int id)
        {
            var blog = context.Blogs.Find(id);
            return View("BlogGet", blog);
        }

        public ActionResult BlogUpdate(Blog blog)
        {
            var blg = context.Blogs.Find(blog.Id);
            blg.Description = blog.Description;
            blg.BlogDate = blog.BlogDate;
            blg.BlogImage = blog.BlogImage;
            blg.BlogDate = blog.BlogDate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CommentList()
        {
            var comments = context.Comments.ToList();
            return View(comments);
        }

        public ActionResult CommentDelete(int id)
        {
            var comment = context.Comments.Find(id);
            context.Comments.Remove(comment);
            context.SaveChanges();
            return RedirectToAction("CommentList");
        }

        public ActionResult CommentGet(int id)
        {
            var comment = context.Comments.Find(id);
            return View("CommentGet", comment);
        }

        public ActionResult CommentUpdate(Comment comment)
        {
            var blg = context.Comments.Find(comment.Id);
            blg.CommentDescription = comment.CommentDescription;
            blg.Mail = comment.Mail;
            blg.UserName = comment.UserName;
            context.SaveChanges();
            return RedirectToAction("CommentList");
        }

    }
}