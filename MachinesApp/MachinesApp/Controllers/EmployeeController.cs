﻿using MachinesApp.Models;
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
    }
}