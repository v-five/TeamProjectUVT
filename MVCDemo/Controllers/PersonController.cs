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
        // GET: Person
        public ActionResult Index()
        {
            var context = new DemoContext();

            var person = new Person
            {
                BasicInfo = new BasicInfo
                {
                    FirstName = "Ion",
                    LastName = "Gheorghe",
                    Title = Title.Mr,
                    Birthday = DateTime.Now
                },
                ProfessionalInfo = new ProfessionalInfo
                {
                    CurrentJobTitle = "Dev",
                    ExpectedSalary = new Range { Min = 2000, Max = 3000 },
                    CurrentSalary = 2000,
                    
                },
                ContactInfo = new ContactInfo
                {
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            City  = "Timisoara",
                            StreetAddress = "Gheorghe Lazar 45/12"
                        },

                        new Address
                        {
                            City = "Timisoara",
                            StreetAddress = "Circumvalatiunii 87",
                            Country = "Romania"
                        }
                    },
                },
                Auth = new Authentication(),
                CandidateStatus = Status.PreScreening
            };


            context.Person.Add(person);
            context.SaveChanges();

            return View(person);
        }
    }
}