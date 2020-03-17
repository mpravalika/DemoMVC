using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
            ViewBag.str = "My First MVC project";
            ViewData["str1"] = "my first project";
            TempData["str2"] = "my project";
            return View();
        }

        public ActionResult Sendobject()
        {
            Emp E = new Emp();
            E.Empno = 10;
            E.Ename = "pra";
            E.Salary = 76000;
            return View(E);//to send object to view
        }

        public ActionResult SendObjects()
        {
            List<Emp> L = new List<Emp>();
            Emp E = null;
            E = new Emp();
            E.Empno = 1;
            E.Ename = "pravs";
            E.Salary = 50000;
            L.Add(E);
            E = new Emp();
            E.Empno = 2;
            E.Ename = "nanni";
            E.Salary = 60000;
            L.Add(E);
            return View(L);//send list of objects
        }


        public ActionResult SendObjectVB()
        {
            Emp E = null;
            E = new Emp();
            E.Empno = 1;
            E.Ename = "pravs";
            E.Salary = 50000;
            ViewBag.e= E;//send object through ViewBag
            ViewData["e"] = E;//send object through ViewData
            return View();
        }
        public ActionResult SendObjectsVb()
        {
            List<Emp> L1 = new List<Emp>();
            Emp E1 = null;
            E1 = new Emp();
            E1.Empno = 1;
            E1.Ename = "pravs";
            E1.Salary = 50000;
            L1.Add(E1);
            E1 = new Emp();
            E1.Empno = 2;
            E1.Ename = "nanni";
            E1.Salary = 60000;
            L1.Add(E1);
            ViewBag.e = L1;//sending list of objects 
            ViewData["e"] = L1;
            return View();
        }
    }
}