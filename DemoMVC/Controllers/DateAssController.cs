using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class DateAssController : Controller
    {
        static List<EMPDATA> L = null;
        // GET: DateAss
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Extractdate()
        {
            DateTime st = DateTime.Parse(Request.Form["txtstdt"]);
            DateTime end = DateTime.Parse(Request.Form["txtenddt"]);
            L = DBOperations.EmpDate(st, end);
            ViewBag.S = L;
            return View("Index",L);
        }
    }
}