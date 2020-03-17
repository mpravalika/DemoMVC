using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DemoMVC.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(Validationscls V)
        //{
        //    return View();
        //}
        public ActionResult Getback(Validationscls V)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Addpage");
            }
            return View("Index");
        }
        public ActionResult Addpage()
        {
            return View();
        }
    }
}