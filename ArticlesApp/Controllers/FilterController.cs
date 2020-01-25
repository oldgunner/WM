using ArticlesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticlesApp.Controllers
{
    public class FilterController : Controller
    {
        ArticleContext db = new ArticleContext();
        // GET: Filter
        public PartialViewResult FilterByCategories()
        {
            IEnumerable<string> categoriesList = db.Articles
               .Select(article => article.Category)
               .Distinct()
               .OrderBy(article => article);

            ViewBag.categories = new SelectList(categoriesList);

            return PartialView(categoriesList);
        }

        [HttpPost]
        public PartialViewResult FilterByCategories(IEnumerable<string> categoriesList)
        {
            return PartialView("Index", categoriesList);
        }

        public PartialViewResult FilterByTags()
        {
            IEnumerable<string> tagsList = db.Articles
               .Select(article => article.Tags)
               .Distinct()
               .OrderBy(article => article);

            ViewBag.tags = new SelectList(tagsList);

            return PartialView(tagsList);
        }

        [HttpPost]
        public PartialViewResult FilterByTags(IEnumerable<string> tagsList)
        {
            return PartialView("Index", tagsList);
        }
    }
}