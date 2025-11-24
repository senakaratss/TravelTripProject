
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Blog p1, HttpPostedFileBase BlogImageFile)
        {
            if (BlogImageFile != null && BlogImageFile.ContentLength > 0)
            {

                string filename = Path.GetFileName(BlogImageFile.FileName);
                string path = Server.MapPath("~/Images/" + filename);
                BlogImageFile.SaveAs(path);
                p1.BlogImage = "/Images/" + filename;
            }
            c.Blogs.Add(p1);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("GetBlog", blog);
        }
        public ActionResult UpdateBlog(Blog p,HttpPostedFileBase NewImage)
        {
            var blog = c.Blogs.Find(p.ID);

            if (NewImage != null && NewImage.ContentLength > 0)
            {
                string filename = Path.GetFileName(NewImage.FileName);
                string path = Server.MapPath("~/Images/" + filename);
                NewImage.SaveAs(path);

                blog.BlogImage = "/Images/" + filename;
            }

            blog.Title = p.Title;
            blog.Description = p.Description;
            blog.Date = p.Date;
            blog.Latitude=p.Latitude;
            blog.Longitude = p.Longitude;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CommentList()
        {
            var comments = c.Comments.ToList();
            return View(comments);
        }
        public ActionResult DeleteComment(int id)
        {
            var comment = c.Comments.Find(id);
            c.Comments.Remove(comment);
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }
        public ActionResult GetComment(int id)
        {
            var comment = c.Comments.Find(id);
            return View("GetComment", comment);
        }

        public ActionResult UpdateComment(Comment p)
        {
            var comment = c.Comments.Find(p.ID);
            comment.Username = p.Username;
            comment.Email = p.Email;
            comment.CommentText = p.CommentText;
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }
        public ActionResult About()
        {
            var values = c.Abouts.ToList();
            return View(values);
        }
        public ActionResult GetAbout(int id)
        {
            var about = c.Abouts.Find(id);
            return View("GetAbout", about);
        }

        public ActionResult UpdateAbout(About p, HttpPostedFileBase ImageFile)
        {
            var about = c.Abouts.Find(p.ID);

            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string filename = Path.GetFileName(ImageFile.FileName);
                string filepath = Path.Combine(Server.MapPath("~/Images/About/"), filename);

                if (!Directory.Exists(Server.MapPath("~/Images/About/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/About/"));
                }
                ImageFile.SaveAs(filepath);
                about.ImageUrl = "/Images/About/" + filename; // URL olarak kaydet

            }
            about.Description = p.Description;
            c.SaveChanges();
            return RedirectToAction("About");
        }
        public ActionResult ContactList()
        {
            var values = c.Contacts.ToList();
            return View(values);
        }
        public ActionResult DeleteContact(int id)
        {
            var contact = c.Contacts.Find(id);
            c.Contacts.Remove(contact);
            c.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}