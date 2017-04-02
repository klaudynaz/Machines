using MachinesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachinesApp.Controllers
{
    public class EmployeeController : Controller

    {   
        [HttpGet]
        public ActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewEmployee(AddNewEmployee addEmployee)
        {
            if (ModelState.IsValid)
            {

                using (var db = new ApplicationDbContext())
                {
                    var employee = new MachinesApp.Models.DB.Employee();// tworze pusty obiekt zgodny z baza danych
                    employee.First_Name = addEmployee.First_Name; // przypisuje pola do obiektu bazodanowego, wczesniej pola nie byly typu bazodanowego
                    employee.Last_Name = addEmployee.Last_Name;
                    employee.Dept = addEmployee.Dept;
                    employee.Position = addEmployee.Position;
                    employee.Email_Adress = addEmployee.Email_Adress;
                    employee.Phone_Number = addEmployee.Phone_Number;
                    db.Employee.Add(employee); // dodaje obiekt do bazy danych
                    db.SaveChanges(); // zachowuje zmiany
                    TempData["Sukces"] = "Pracownik został dodany";
                }
              
            }
            return View();

        }



        [HttpGet] 
        public ActionResult ViewNewEmployee()
        {

            using (var db = new ApplicationDbContext()) {

                var viewemployee = db.Employee.ToList();
                return View(viewemployee);
            }
                
        }
    }
}