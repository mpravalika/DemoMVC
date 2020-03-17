using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class BoundController : Controller
    {
        // GET: Bound
        public ActionResult Index()
        {
            Emp E = new Emp();
            return View(E);
        }
        public ActionResult Display(Emp e)
        {
            return View(e);
        }

        //display using Overloded method
        public ActionResult Index1()
        {
            Emp E = new Emp();
            return View(E);
        }
        [HttpPost]//after pressing the button/control
        public ActionResult Index1(Emp E)
        {
            return View("Display", E);
        }

        //UnBound Controller
        public ActionResult Unbound()
        {
            return View();
        }
        public ActionResult ShowData()
        {
            Emp E = new Emp();
            E.Empno =int.Parse( Request.Form["txtempno"]);
            E.Ename = Request.Form["txtename"];
            E.Salary = double.Parse(Request.Form["txtsal"]);
            return View(E);
        }
    }
}