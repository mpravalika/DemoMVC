using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class EventsEx2Controller : Controller
    { 
        // GET: EventsEx2/////USING Submit button;
        public ActionResult Index()
        {
            ViewBag.EL = DBOperations.GetEmp();
            return View();
        }
        public ActionResult DelEmpdata()
        {
            int eno = int.Parse(Request.Form["ddlEmpno"]);
            ViewBag.msg = DBOperations.DelEmp(eno);
            ViewBag.EL = DBOperations.GetEmp();
            return View("Index");
        }
    }
}