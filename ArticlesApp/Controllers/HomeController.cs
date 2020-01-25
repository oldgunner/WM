using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArticlesApp.Models;

namespace ArticlesApp.Controllers
{
    public class HomeController : Controller
    {
        ArticleContext db = new ArticleContext();
        int pageSize = 4; // количество объектов на страницу

        public ActionResult Index(string category, int page = 1)
        {
            IndexViewModel model = new IndexViewModel
            {
                Articles = db.Articles
                .Where(p => category == null || p.Category == category)
                .OrderBy(article => article.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        db.Articles.Count() :
                        db.Articles.Where(a => a.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
    }
}