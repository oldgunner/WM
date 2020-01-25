using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArticlesApp.Models;

namespace ArticlesApp.Controllers
{    
    public class AdminController : Controller
    {
        private ArticleContext db = new ArticleContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        public ViewResult Create()
        {
            return View("Edit", new Article());
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Article dbEntry = db.Articles.Find(id);
            if (dbEntry != null)
            {                
                db.Articles.Remove(dbEntry);
                db.SaveChanges();
                TempData["message"] = string.Format("Статья \"{0}\" была удалена", dbEntry.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Article article = db.Articles
                .FirstOrDefault(a => a.Id == id);
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (article.Id == 0)
                    db.Articles.Add(article);
                else if (image != null)
                {
                    Article dbEntry = db.Articles.Find(article.Id);
                    article.HeroImage = image.ContentType;
                    article.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(article.ImageData, 0, image.ContentLength);                    

                    if (dbEntry != null)
                    {
                        dbEntry.Name = article.Name;
                        dbEntry.Description = article.Description;
                        dbEntry.ShortDescription = article.ShortDescription;
                        dbEntry.Category = article.Category;
                        dbEntry.Tags = article.Tags;
                        dbEntry.HeroImage = article.HeroImage;
                        dbEntry.ImageData = article.ImageData;
                    }
                }                
                db.SaveChanges();
                TempData["message"] = string.Format("Изменения в статье \"{0}\" были сохранены", article.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(article);
            }
        }

        public FileContentResult GetImage(int id)
        {
            Article article = db.Articles
                .FirstOrDefault(a => a.Id == id);

            if (article != null)
            {
                return File(article.ImageData, article.HeroImage);
            }
            else
            {
                return null;
            }
        }
    }
}