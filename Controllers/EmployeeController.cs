using EmPCRUD280524.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmPCRUD280524.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Delete(int id)
        {
            DB240224Entities dbo = new DB240224Entities();
            var emp = dbo.tblEmps.FirstOrDefault(x => x.id == id);
            dbo.tblEmps.Remove(emp);
            dbo.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(tblEmp em)
        {
            DB240224Entities dbo = new DB240224Entities();
            var emp = dbo.tblEmps.FirstOrDefault(x => x.id == em.id);
            if (emp!=null)
            {
                emp.name = em.name;
                    emp.mobile=em.mobile;
            }
            int n=dbo.SaveChanges();
            if (n>0)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            DB240224Entities dbo = new DB240224Entities();
            var emp = dbo.tblEmps.FirstOrDefault(x => x.id == id);
              
            return View(emp);
        }
        // GET: Employee
        public ActionResult Index()
        {
            DB240224Entities dbo = new DB240224Entities();
            List<tblEmp> emps = dbo.tblEmps.ToList();
            return View(emps);
        }
        public ActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmp(tblEmp emp)
        {
            DB240224Entities dbo = new DB240224Entities();
            dbo.tblEmps.Add(emp);
            int n = dbo.SaveChanges();
            if (n>0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}