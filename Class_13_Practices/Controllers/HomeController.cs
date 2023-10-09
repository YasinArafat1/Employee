using Class_13_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_13_Practices.Controllers
{
    public class HomeController : Controller
    {
       private EmployeeDbContext db = new EmployeeDbContext();
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.deptList = new List<SelectListItem> 
            {
            new SelectListItem {Text="It",Value="IT"},
            new SelectListItem {Text="HR",Value="HR"},
            new SelectListItem {Text="Marketing",Value="Marketing"},
            new SelectListItem{Text="--Select--",Value="",Selected=true}
            
            };

            return View();
        }


        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deptList = new List<SelectListItem>
            {
            new SelectListItem {Text="It",Value="IT"},
            new SelectListItem {Text="HR",Value="HR"},
            new SelectListItem {Text="Marketing",Value="Marketing"},
            new SelectListItem{Text="--Select--",Value="",Selected=true}

            };
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
           Employee emp = db.Employees.First(x=>x.Id==id);

            ViewBag.deptList = new List<SelectListItem>
            {
            new SelectListItem {Text="It",Value="IT"},
            new SelectListItem {Text="HR",Value="HR"},
            new SelectListItem {Text="Marketing",Value="Marketing"},
            new SelectListItem{Text="--Select--",Value="",Selected=true}

            };

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        
        return View(emp);
        }

        public ActionResult Delete(int id)
        {
            Employee emp = db.Employees.First( x=>x.Id==id);
            ViewBag.deptList = new List<SelectListItem>
            {
            new SelectListItem {Text="It",Value="IT"},
            new SelectListItem {Text="HR",Value="HR"},
            new SelectListItem {Text="Marketing",Value="Marketing"},
            new SelectListItem{Text="--Select--",Value="",Selected=true}

            };

            return View(emp);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult doDelete(int id)
        { 
        Employee emp = db.Employees.First(x=>x.Id==id);
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }



    }
}