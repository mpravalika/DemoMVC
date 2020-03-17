using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class AssignmentEmpController : Controller
    {
        List<EMPDATA> L = null;
        // GET: AssignmentEmp
        public ActionResult Index()
        {
            L = DBOperations.GetEmp();
            ViewBag.S = L;
            return View();
        }
        public ActionResult Radio()
        {
            int empno = Convert.ToInt32(Request.Form["rdb"]);
            EMPDATA E = DBOperations.extractemp(empno);
            return View(E);
        }
    }
}