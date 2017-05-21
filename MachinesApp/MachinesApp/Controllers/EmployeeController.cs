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
        [Authorize(Roles = "admin")]
        public ActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddNewEmployee(AddNewEmployee addEmployee)
        {
            if (ModelState.IsValid)
            {

                using (var db = new ApplicationDbContext())
                {
                    var listaadresow = db.Users.Where(x => x.UserName == addEmployee.Email_Adress).ToList();
                    var listaadresow2 = db.Employee.Where(x => x.Employee_email == addEmployee.Email_Adress).ToList();
                    if (listaadresow.Count() == 0)
                    {
                        TempData["Komunikat"] = "Pracownik o takim adresie emial nie został zarejestrowany w systemie";
                        return View();
                    }
                    if (listaadresow2.Count() >= 1)
                    {
                        TempData["Komunikat"] = "Pracownik o takim adresie emial został już zarejestrowany w systemie";
                        return View();
                    }



                    var employee = new MachinesApp.Models.DB.Employee();// tworze pusty obiekt zgodny z baza danych
                    employee.Employee_email = addEmployee.Email_Adress;
                    employee.First_Name = addEmployee.First_Name; 
                    employee.Last_Name = addEmployee.Last_Name;
                    employee.Dept = addEmployee.Dept;
                    employee.Position = addEmployee.Position;
                    employee.Email_Adress = addEmployee.Email_Adress;
                    employee.Phone_Number = addEmployee.Phone_Number;
                    db.Employee.Add(employee); // dodaje obiekt do bazy danych

                    var emp = db.Users.FirstOrDefault(x => x.UserName == addEmployee.Email_Adress);
                    //pobieram konkretnego uzytkownika z tabeli aspnetusers za pomoca emaila
                    emp.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole {UserId=emp.Id,RoleId="user"});
                    
                    db.SaveChanges(); // zachowuje zmiany
                    TempData["Sukces"] = "Pracownik został dodany";
                }

            }
            return View();

        }



        [HttpGet]
        public ActionResult ViewNewEmployee()
        {

            using (var db = new ApplicationDbContext())
            {

                var viewemployee = db.Employee.ToList();
                return View(viewemployee);
            }

        }

        [HttpGet]
        public ActionResult RemoveEmployee(int employeeid)
        {

            using (var db = new ApplicationDbContext())

            {   
                var removed = db.Employee.FirstOrDefault(x => x.Id == employeeid);
                
                if (removed == null)

                {
                    TempData["Remove"] = "Pracownik o takim id nie istnieje w systemie";

                }

                else
                {
                    db.Employee.Remove(removed);
                    db.SaveChanges();
                    TempData["Remove"] = "Pracownik został usunięty z systemu";
                }

                return RedirectToAction("ViewNewEmployee", "Employee"); 
            }
        }


        [HttpGet]
        public ActionResult EditEmployee(int employeeid)
        {

            using (var db = new ApplicationDbContext())
            {
                var edited = db.Employee.FirstOrDefault(x => x.Id == employeeid);
                return View(edited);
            }

        }


        [HttpPost]
        public ActionResult EditEmployee(Models.DB.Employee editedemp)
        {
            using (var db = new ApplicationDbContext())
            {
                var edited = db.Employee.FirstOrDefault(x => x.Id == editedemp.Id);
               edited.Employee_email = editedemp.Email_Adress;
                edited.First_Name = editedemp.First_Name;
                edited.Last_Name = editedemp.Last_Name;
                edited.Dept = editedemp.Dept;
                edited.Position = editedemp.Position;
                edited.Email_Adress = editedemp.Email_Adress;
                edited.Phone_Number = editedemp.Phone_Number;
                db.SaveChanges();
                return RedirectToAction("ViewNewEmployee", "Employee");


            }
        }







    }
}