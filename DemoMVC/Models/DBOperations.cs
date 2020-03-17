using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DemoMVC.Models
{
    public class DBOperations
    {
        static DemoEntities D = new DemoEntities();
       
        public static string insertEmp(EMPDATA A)
        {
            try
            {
                D.EMPDATAs.Add(A);
                D.SaveChanges();
            }
            catch(DbUpdateException E)
            {
                SqlException ex=E.GetBaseException() as SqlException;
                if( ex.Message.Contains("FK__EMPDATA__DEPTNO__3587F3E0"))
                {
                    return "no proper detno";
                }
                else if (ex.Message.Contains("EMP_PK"))
                {
                    return "empno cannot be same";
                }
                else
                {
                    return "Error occured";
                }
            }
            return "Row inserted";
        }
        public static List<EMPDATA> GetDept(int Deptno)
        {
            var LE = from L in D.EMPDATAs
                     where L.DEPTNO ==Deptno
                     select L;
            return LE.ToList();
        }

        public static List<DEPTDATA> getdata()
        {
            var Dept = from D1 in D.DEPTDATAs//getting dptdata from databse
                       select D1;
            return Dept.ToList();
        }

        public static List<EMPDATA> GetEmp()
        {
            var EL = from L in D.EMPDATAs
                     select L;
            return EL.ToList();
        }
        public static string DelEmp(int empno)
        {
            var LE =(from L1 in D.EMPDATAs
                     where L1.EMPNO == empno
                     select L1).FirstOrDefault();
            D.EMPDATAs.Remove(LE);
            D.SaveChanges();
            return  empno+" employee details Deleted";
        }
        public static EMPDATA extractemp(int empno)
        {
            var Le = from E in D.EMPDATAs //Extracting details of emp with empno from Database
                    where E.EMPNO == empno
                    select E;
            return Le.FirstOrDefault(); 
        }
        public static string updatedata(int empno,EMPDATA emp)
        {
            var LE = from L in D.EMPDATAs //for getting original details of empno.
                     where L.EMPNO == empno
                     select L;
            foreach(var item in LE)
            {
                item.JOB = emp.JOB;
                item.MGR = emp.MGR;
                item.SAL = emp.SAL;
                item.COMM= emp.COMM;
                item.DEPTNO = emp.DEPTNO;
            }
            D.SaveChanges();
            return "1 Row Updated";
        }

        public static List<EMPDATA> EmpDate(DateTime st,DateTime end)
        {
            var EL = from d in D.EMPDATAs
                     where d.HIREDATE > st && d.HIREDATE < end
                     select d;
            return EL.ToList();
        }
        //public static EMPDATA RadioDisplay(int empno)
        //{
        //    EMPDATA E = (from e in D.EMPDATAs
        //                 where e.EMPNO == empno
        //                 select e).FirstOrDefault();
        //    return E;
        //}
    }
}