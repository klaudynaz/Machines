using MachinesApp.Models;
using MachinesApp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachinesApp.Controllers
{
    public class KnowledgeController : Controller
    {
    //    [HttpGet]
    //    [Authorize(Roles = "admin")]
    //    public ActionResult AddNewArticle()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    [Authorize(Roles = "admin")]
    //    public ActionResult AddNewArticle(AddNewArticle addarticle)
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            using (var db = new ApplicationDbContext())
    //            {


    //                var knowledge = new MachinesApp.Models.DB.Knowledge();// tworze pusty obiekt zgodny z baza danych
    //                knowledge.Id_article = addarticle.Id_article;
    //                knowledge.Date = addarticle.Date;
    //                knowledge.Title = addarticle.Title;
    //                knowledge.Text = addarticle.Text;


    //                db.Employee.Add(knowledge); // dodaje obiekt do bazy danych


    //                db.SaveChanges(); // zachowuje zmiany
    //                TempData["Article"] = "Artykuł został dodany";
    //            }

    //            return View();

    //        }



    //    }
    }
}