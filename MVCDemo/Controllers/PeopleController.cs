using MVCDemo.Models;
using System.Web.Mvc;
using Database;
using System.Linq;
using System.Collections.Generic;
using System;

namespace MVCDemo.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            var context = new Database.DemoContext();
            IEnumerable<Person> allperson = context.Person
                .Include("BasicInfo")
                .Include("ContactInfo")
                .Include("ProfessionalInfo").ToList();

            int i;
            if(int.TryParse(Request["yearsOfExperience"], out i))
                allperson = allperson.Where(p => p.ProfessionalInfo.YearsOfExperience == i);
            if(!string.IsNullOrWhiteSpace(Request["city"]))
                allperson = allperson.Where(p => p.ContactInfo.Addresses.Any(a => a.City == Request["city"]));
            if (!string.IsNullOrWhiteSpace(Request["lastDegreeEarned"]))
                allperson = allperson.Where(p => p.ProfessionalInfo.LastDegreeEarned == Request["lastDegreeEarned"]);
            if (int.TryParse(Request["currentSalary"], out i))
                allperson = allperson.Where(p => p.ProfessionalInfo.CurrentSalary == i);
            if (int.TryParse(Request["expectedSalary"], out i))
                allperson = allperson.Where(p => (p.ProfessionalInfo.ExpectedSalary.Min) < i && (p.ProfessionalInfo.ExpectedSalary.Max > i));
            if (int.TryParse(Request["age"], out i))
                allperson = allperson.Where(p => (DateTime.Today.Year - p.BasicInfo.Birthday.Year) == i);
            return View(allperson.ToList());
  
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
            return Redirect("People/EditPerson/");
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
    }
}

