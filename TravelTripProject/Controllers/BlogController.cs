using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment bc = new BlogComment();
        public ActionResult Index()
        {
            //var blogs = c.Blogs.ToList();
            bc.Value1 = c.Blogs.ToList();
            bc.Value3 = c.Blogs.OrderByDescending(x=>x.Date).Take(3).ToList();
            bc.Value4 = c.Comments.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(bc);
        }
        public ActionResult BlogDetail(int id)
        {
            //var blog = c.Blogs.Where(x=>x.ID==id).ToList();
            bc.Value1 = c.Blogs.Where(x => x.ID == id).ToList();
            bc.Value2 = c.Comments.Where(x => x.Blogid == id).ToList();
            bc.Value3 = c.Blogs.OrderByDescending(x => x.Date).Take(3).ToList();
            bc.Value4 = c.Comments.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(bc);
        }
        [HttpGet]
        public PartialViewResult WriteComment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult WriteComment(Comment comment)
        {
            c.Comments.Add(comment);
            c.SaveChanges();
            return PartialView();
        }
    }
}