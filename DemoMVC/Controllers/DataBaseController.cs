using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class DataBaseController : Controller
    {
        static List<EMPDATA> EL = null;
        static List<DEPTDATA> List = null;
        // GET: DataBase
        public ActionResult Index()
        {
            EMPDATA E = new EMPDATA();
            return View(E);
        }
        [HttpPost]
        public ActionResult Index(EMPDATA E)
        {
            ViewBag.msg= DBOperations.insertEmp(E);
            return View();
        }
        public ActionResult GetDeptdata()
        {
            return View();
        }
        
        public ActionResult GetDept()
        {
            int deptno = int.Parse(Request.Form["txtdeptno"]);
            List<EMPDATA> L= DBOperations.GetDept(deptno);
            return View("GetDeptdata",L);
        }

        public ActionResult GetDetails()
        {
            List = DBOperations.getdata();
            ViewBag.DL = List;//DL has deptdata
            return View();
        }
        public ActionResult sendDept()
        {
            int deptno = int.Parse(Request.QueryString["d"]);//getting selected dno
            ViewBag.DL = List;
            ViewBag.S = deptno;
            List<EMPDATA> EL= DBOperations.GetDept(deptno);//fetching detno from query string and assign empdata to EL
            return View("GetDetails",EL);
        }
        public ActionResult GetEmpdata()
        {
            EL=DBOperations.GetEmp();
            ViewBag.E = EL;
            return View();
        }
        public ActionResult Deletedata()
        {
            int empno = int.Parse(Request.Form["ddlempno"]);
            ViewBag.S= DBOperations.DelEmp(empno);
            ViewBag.E = DBOperations.GetEmp();
            return View("GetEmpdata");
        }
        
    }
}