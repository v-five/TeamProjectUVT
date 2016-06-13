using MVCDemo.Models;
using System.Web.Mvc;
using Database;
using System.Linq;
using Membership.Providers;
using System;
using System.IO;
using System.Collections.Generic;
using MVCDemo.Utils;

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
                allperson = allperson.Where(p => p.ContactInfo.Address.City == Request["city"]);
            if (!string.IsNullOrWhiteSpace(Request["lastDegreeEarned"]))
                allperson = allperson.Where(p => p.ProfessionalInfo.LastDegreeEarned == Request["lastDegreeEarned"]);
            if (int.TryParse(Request["currentSalary"], out i))
                allperson = allperson.Where(p => p.ProfessionalInfo.CurrentSalary == i);
            if (int.TryParse(Request["age"], out i))
                allperson = allperson.Where(p => (DateTime.Today.Year - p.BasicInfo.Birthday.Year) == i);
            return View(allperson.ToList());
  
        }

        public ActionResult Person(int? id)
        {
            if (!id.HasValue) return View();

            var context = new DemoContext();
            var person = context.Person
                .Include("BasicInfo")
                .Include("ContactInfo")
                .Include("ProfessionalInfo")
                .SingleOrDefault(p => p.Id == id.Value);

            // TODO: in view sa se populeze datele care exista
            return View(person);
        }
        
        [HttpGet]
        public ActionResult EditPerson(int? id)
        {
            try
            {
                var membershipProvider = new MembershipProvider();
                var person = membershipProvider.GetUserInformation();

                return View(person);
            }
            catch (Exception ex)
            { 
                return View(new Person());
            }
        }

        [HttpPost]
        public ActionResult EditPerson(Person person)
        {
            //TODO: Tudor adauga logica de save person cu datele din formular
            return Redirect("People/person/" + person.Id);
        }
        
        [HttpDelete]
        public string DeletePerson(int? id)
        {
            if (!id.HasValue)
            {
                return "No Id Selected";
            }

            var context = new DemoContext();
            var itemToDelete = context.Person.Find(id.Value);
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
            var person = new Person
            {
                BasicInfo = new BasicInfo
                {
                    Birthday = DateTime.Now,
                    FirstName = Request.Form["firstName"],
                    LastName = Request.Form["lastName"],
                    Title = Request.Form["title"]
                },
                ContactInfo = new ContactInfo
                {
                    Address = new Address
                    {
                        City = Request.Form["city"],
                        County = Request.Form["county"],
                        Country = Request.Form["country"],
                        StreetName = Request.Form["streetName"],
                        StreetNumber = Request.Form["streetNumber"],
                        IsFlat = Request.Form["isFlat"].Equals("on") ? true : false,
                        Entrance = Request.Form["entrance"],
                        FlatNumber = Request.Form["flatNumber"]    
                    },
                    Fax = Request.Form["fax"],
                    PhoneNumber1 = string.IsNullOrEmpty(Request.Form["phone1"]) ? string.Empty : Request.Form["phone1"],
                    PhoneNumber2 = string.IsNullOrEmpty(Request.Form["phone2"]) ? string.Empty : Request.Form["phone2"],
                    PhoneNumber3 = string.IsNullOrEmpty(Request.Form["phone3"]) ? string.Empty : Request.Form["phone3"],
                    Website = Request.Form["website"]
                },
                ProfessionalInfo = new ProfessionalInfo
                {
                     CurrentJobTitle = Request.Form["jobTitle"],
                     CurrentSalary = Convert.ToInt32(Request.Form["currentSalary"]),
                     ExpectedSalary = Request.Form["expectedSalary"],
                     LastDegreeEarned = Request.Form["degree"],
                     YearsOfExperience = Convert.ToInt32(Request.Form["yearsOfExperience"]),
                     Skills = Request.Form["skills"]
                }
            };

            if (string.IsNullOrEmpty(person.ContactInfo.PhoneNumber1))
            {
                person.ContactInfo.PhoneNumber1 = person.ContactInfo.PhoneNumber2;
                person.ContactInfo.PhoneNumber2 = person.ContactInfo.PhoneNumber3;
                person.ContactInfo.PhoneNumber3 = string.Empty;
            }

            if (string.IsNullOrEmpty(person.ContactInfo.PhoneNumber2))
            {
                person.ContactInfo.PhoneNumber2 = person.ContactInfo.PhoneNumber3;
                person.ContactInfo.PhoneNumber3 = string.Empty;
            }
            
            FileManagementUtils.SaveUploadedCV(person);
            var membershipProvider = new MembershipProvider();
            membershipProvider.UpdateUserInformation(person);
            
            return RedirectToAction("EditPerson", "People");
        }
    }
}

