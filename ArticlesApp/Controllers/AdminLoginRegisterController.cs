using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ArticlesApp.Models;

namespace ArticlesApp.Controllers
{
    public class AdminLoginRegisterController : Controller
    {
        // GET: AdminLoginRegister
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLogin model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд 
                Admin admin = null;
                using (ArticleContext db = new ArticleContext())
                {
                    admin = db.Admins.FirstOrDefault(a => a.Name == model.Name && a.Password == model.Password);

                }
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AdminRegister model)
        {
            if (ModelState.IsValid)
            {
                Admin admin = null;
                using (ArticleContext db = new ArticleContext())
                {
                    admin = db.Admins.FirstOrDefault(a => a.Email == model.Email && a.Name == model.Name);
                }
                if (admin == null)
                {
                    // создаем нового пользователя 
                    using (ArticleContext db = new ArticleContext())
                    {
                        db.Admins.Add(new Admin { Name = model.Name, Email = model.Email, Password = model.Password, Age = model.Age });
                        db.SaveChanges();

                        admin = db.Admins.Where(a => a.Name == model.Name && a.Email == model.Email && a.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд 
                    if (admin != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Login", "AdminLoginRegister");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}