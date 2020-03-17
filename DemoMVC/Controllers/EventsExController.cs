using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class EventsExController : Controller
    {
        // GET: EventsEx/////USING Onblur();
        public ActionResult Index()
        {
            //step1
            ViewBag.EL= DBOperations.GetEmp();
            return View();
        }
        public ActionResult Getdata()
        {
            int eno = int.Parse(Request.QueryString["e"]);
            ViewBag.msg= DBOperations.DelEmp(eno);
            ViewBag.EL = DBOperations.GetEmp();
            return View("Index");
        }
    }
}