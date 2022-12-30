using BuiThiHai_2019606166.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiThiHai_2019606166.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var us = db.tblUsers.Where(u => u.username == username && u.password == password).FirstOrDefault();
            if (us == null)
            {
                ViewBag.errLogin = " không thể đanwg nhập";
                return View("Login");
            }
            else
            {
                Session["username"] = username;
                return RedirectToAction("Index", "NhanViens");
            }    
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "NhanViens");
        }
    }
}