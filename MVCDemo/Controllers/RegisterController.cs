using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using Membership.Providers;

namespace MVCDemo.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            var membership = new MembershipProvider();


            //TODO: Replace hard coded values with the proper form ones
            //      Implement validation on the form fields and check they are not empty / invalid  
            var person = new Person
            {
                Auth = new Authentication
                {
                    Username = "testusername",
                    Password = "testpw"
                },
                BasicInfo = new BasicInfo
                {
                    Birthday = DateTime.Now.Date,
                    FirstName = "FirstName",
                    LastName = "Lastname",
                    Title = Title.Mr
                },
                ContactInfo = new ContactInfo
                {
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            City = "asd",
                            County = "asd",
                            Country = "asd",
                            StreetAddress = "asd"
                        }
                    },
                     Email = "asdasd"
                 },
                 ProfessionalInfo = new ProfessionalInfo
                 {
                    CurrentJobTitle = "asd",
                    ExpectedSalary = new Range
                    {
                        Min = 1,
                        Max = 2
                    },
                    LastDegreeEarned = "asd",
                    YearsOfExperience = 2
                 }
            };

            try
            {
                membership.PerformRegistration(person);
            }
            catch (Exception ex)
            {
                //TODO: return view with proper error
            }

            //TODO: replace with proper version
            return View();
        }
    }
}