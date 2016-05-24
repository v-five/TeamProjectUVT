using Database;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            var email = Request["email"];
            var pass = Request["password"];
            var cpass = Request["confirm-password"];
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                return Redirect("/?error=emptyMailOrPassword");
            }
            if(pass != cpass)
            {
                return Redirect("/?error=passwordNotEqual");
            }
            var person = new Person
            {
                Auth = new Authentication
                {
                    Username = email,
                    Password = pass
                },
                ContactInfo = new ContactInfo
                {
                    Email = email,
                    PhoneNumbers = new List<string>(),
                    Addresses = new List<Address>(),
                    SocialWebSites = new List<SocialMedia>()
                },
                BasicInfo = new BasicInfo
                {
                    Birthday = DateTime.Now
                },
                ProfessionalInfo = new ProfessionalInfo
                {
                    ExpectedSalary = new Range(),
                    Skills = new List<Skill>()
                }
            };

            var context = new DemoContext();
            context.Person.Add(person);
            context.SaveChanges();

            return Redirect("/People/EditPerson/" + person.Id);
        }
    }
}