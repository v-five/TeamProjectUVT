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
            var person = context.Person.Include("BasicInfo").Include("ContactInfo").Single(p => p.Id == id);
            
            return View(person);
        }
    }
}