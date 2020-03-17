using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class RadioAssController : Controller
    {
        static List<DEPTDATA> DL = null;
        static List<EMPDATA> EL = null;
        // GET: RadioAss
        public ActionResult Index()
        {
            DL = DBOperations.getdata();
            ViewBag.D = DL;
            return View();
        }
        public ActionResult Radiobtn()
        {
            DL = new List<DEPTDATA>();
            ViewBag.D = DL;
            if (Request.Form["txtstdt"] != null && Request.Form["txtenddt"] != null)
            {
                DateTime st = DateTime.Parse(Request.Form["txtstdt"]);
                DateTime end = DateTime.Parse(Request.Form["txtenddt"]);
                EL = DBOperations.EmpDate(st, end);
                ViewBag.L = EL;
            }
            if (Request.Form["ddldept"] != null)
            {
                int deptno = int.Parse(Request.Form["ddldept"]);
                EL = DBOperations.GetDept(deptno);
                ViewBag.L = EL;
            }
            return View("Index");
        }
    }
}