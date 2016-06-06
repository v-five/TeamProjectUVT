using MVCDemo.Models;
using System.Web.Mvc;
using Database;
using System.Linq;
using Membership.Providers;
using System;
using System.Collections.Generic;

namespace MVCDemo.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            // TODO: view all persons
            return View();
        }

        public ActionResult Person(int id)
        {
            var context = new DemoContext();
            var person = context.Person
                .Include("BasicInfo")
                .Include("ContactInfo")
                .Include("ProfessionalInfo")
                .SingleOrDefault(p => p.Id == id);

            // TODO: in view sa se populeze datele care exista
            return View(person);
        }
        
        [HttpGet]
        public ActionResult EditPerson(int id)
        {
            var context = new DemoContext();
            var person = context.Person
                .Include("BasicInfo")
                .Include("ContactInfo")
                .Include("ProfessionalInfo")
                .SingleOrDefault(p => p.Id == id);

            // TODO: in view sa se populeze datele care exista
            return View(person);
        }

        [HttpPost]
        public ActionResult EditPerson(Person person)
        {
            //TODO: Tudor adauga logica de save person cu datele din formular
            return Redirect("People/person/" + person.Id);
        }
        
        [HttpDelete]
        public string DeletePerson(int id)
        {
            var context = new DemoContext();
            var itemToDelete = context.Person.Find(id);
            if (itemToDelete != null)
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

        [HttpPost]
        public ActionResult SaveUserInformation()
        {
            var request = Request.Form;

            var person = new Person
            {
                BasicInfo = new BasicInfo
                {
                    Birthday = Convert.ToDateTime(Request.Form["birthday"]),
                    FirstName = Request.Form["firstName"],
                    LastName = Request.Form["lastName"]
                },
                ContactInfo = new ContactInfo
                {
                    Addresses = new List<Address>
                       {
                           new Address
                           {
                                City = Request.Form["city"],
                                County = Request.Form["county"],
                                Country = Request.Form["country"],
                                StreetAddress = Request.Form["street"]
                           }
                       },
                    Fax = Request.Form["fax"],
                    PhoneNumbers = new List<string>
                       {
                           Request.Form["phoneNumber"]
                       },
                    Website = Request.Form["website"]
                }
            };

            var membershipProvider = new MembershipProvider();
            membershipProvider.UpdateUserInformation(person);

            return View();
        }
    }
}

