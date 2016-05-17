using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Person(int id)
        {
            var context = new DemoContext();
            var person = context.Person.Include("BasicInfo").Include("ContactInfo").Include("ProfessionalInfo").Single(p => p.Id == id);
            
            return View(person);
        }



        public string DeletePerson(int id)
        {
            var context = new DemoContext();

            var itemToDelete = context.Person.Find(id);
            bool itemToDeleteExists = context.Person.Any(person => person.Id.Equals(itemToDelete.Id));

            if (itemToDeleteExists)
            {
                itemToDelete.IsDeleted = true;
                context.SaveChanges();
                string message = "204";
                return message;

            }
            else
            {

                string message = "404";
                return message;
            }







        }
    }
}