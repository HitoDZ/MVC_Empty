using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using MVC_Empty.Models;

namespace MVC_Empty.App_Start
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.Items = db.GetItems();
            var a = ViewBag.Items;
            //MVC_Empty.Models.Users b = a;

            return View();
        }
        [HttpGet]
        public ActionResult Edit(String login)
        {
            DataModel db = new DataModel();
            return View(db.GetUser(login));
        }
        public ActionResult Edit(Users obj)
        {
            if (ModelState.IsValid)
            {
                DataModel db = new DataModel();
                db.Save(obj);
                return RedirectToAction("Admin");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Indeex(string login, string password)
        {
            DataModel db = new DataModel();
            Users reg = db.GetUser(login);
            if (DataModel.a >= 3)
            {
                throw new Exception("ACESS_BLOCKED");
            }
            if (reg == null)
            {
                ViewBag.Answer = "No such user. Try again.";
                return View("Index");
            }

            if (reg.Password == password)
            {
                ViewBag.User = login;
                if (reg.Status == 2)
                    return View("MainWindow_cw");
                if (reg.Status == 1)
                {
                    DataModel t1 = new DataModel();
                    ViewBag.Item = t1.GetItems();
                    return View("Admin");
                }
            }
            else
            {
                ++DataModel.a;
                
                ViewBag.Answer = "Password is incorect";
                return View("Index");
            }

            // id - имя клиента, заказы которого необходимо выводить на странице.
           // ViewBag.Answer = "No such user. Try again.";
            return View("Index");
        }
        public ActionResult MainWindow_cw()
        {
            DataModel db = new DataModel();
            ViewBag.Items = db.GetItems();
            var a = ViewBag.Items;
            //MVC_Empty.Models.Users b = a;

            return View();
        }
        public ActionResult Admin()
        {
            DataModel db = new DataModel();
            ViewBag.Item = db.GetItems();

            //MVC_Empty.Models.Users b = a;

            return View();
        }
    }
}