using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachinesApp.Controllers
{
    public class HireController : Controller
    {
        [HttpGet]
        public ActionResult AddNewHire()
        {
            using (var db = new Models.ApplicationDbContext())
            {
                var employees = db.Employee.ToList();
                var machines = db.Machine.ToList();

                var hire = new MachinesApp.Models.AddNewHire();
                hire.Employees = employees;
                hire.Machines = machines;


                return View(hire);
            }
        }




    }
}