using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;
using Models;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var context = new DemoContext();
            
            var person = new Person
            {
                Firstname = "Ion",
                Lastname = "Petrescu",
                Address = new Address
                {
                    StreeAddress = "Calea Sagului",
                    HouseNumber = 24,
                    AppartmentNumber = 32,
                    Type = AddressType.Permanent
                }
            };
            context.Person.Add(person);
            context.SaveChanges();

            return View(person);
        }
    }
}