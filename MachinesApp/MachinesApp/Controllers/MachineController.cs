using MachinesApp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachinesApp.Controllers
{
    public class MachineController : Controller
    {


        [HttpGet]
        public ActionResult AddNewMachine()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewMachine(AddNewMachine addMachine)
        {
            if (ModelState.IsValid)
            {

                using (var db = new Models.ApplicationDbContext())
                {
                    var machine = new MachinesApp.Models.DB.Machine();// tworze pusty obiekt zgodny z baza danych
                    machine.Id_machine = addMachine.Id_machine; // przypisuje pola do obiektu bazodanowego, wczesniej pola nie byly typu bazodanowego
                    machine.Serial_number = addMachine.Serial_number;
                    machine.Producer = addMachine.Producer;
                    machine.Model = addMachine.Model;
                    machine.Size = addMachine.Size;
                    machine.Description = addMachine.Description;
                    machine.Weight = addMachine.Weight;
                    db.Machine.Add(machine); // dodaje obiekt do bazy danych
                    db.SaveChanges(); // zachowuje zmiany
                    TempData["Sukces2"] = "Maszynę dodano do bazy";
                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult ViewNewMachine()
        {

            using (var db = new Models.ApplicationDbContext())
            {

                var viewmachine = db.Machine.ToList();
                return View(viewmachine);
            }

        }


    }
}
