using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Extractemp()
        {
            int empno = int.Parse(Request.QueryString["e"]);//getting empno from view addressbar.
            EMPDATA E = DBOperations.extractemp(empno);//empno is passed to model and storing details in E.
            return View("Index",E);//passing extracted details to view.
        }
        public ActionResult updatebtn(EMPDATA p)
        {
            int empno = int.Parse(Request.Form["EMPNO"]);
            string S = DBOperations.updatedata(empno,p);
            ViewBag.msg = S;
            return View("Index");
        }
    }
}