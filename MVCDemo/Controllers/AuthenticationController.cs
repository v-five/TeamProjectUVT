using Database;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Membership.Providers;
using System.Security.Authentication;

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
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                return Redirect("/?error=emptyMailOrPassword");
            }
            if (pass != cpass)
            {
                return Redirect("/?error=passwordNotEqual");
            }
            /*else // don't comment else
            {
                return Redirect("../People/EditPerson/");
            }*/
            var person = new Person //comment everithing from var person to return redirect
            {
                Auth = new Authentication
                {
                    Username = email,
                    Password = pass
                },
                ContactInfo = new ContactInfo
                {
                    Email = email,
                    Address = new Address(),
                    SocialWebSites = new List<SocialMedia>()
                },
                BasicInfo = new BasicInfo
                {
                    Birthday = DateTime.Now
                }
            };

            try
            {
                var membershipProvider = new MembershipProvider();
                membershipProvider.PerformRegistration(person);
                var authentication = new Authentication
                {
                    Username = !string.IsNullOrEmpty(person.Auth.Username) ? person.Auth.Username : person.ContactInfo.Email,
                    Password = person.Auth.Password,
                };
                membershipProvider.PerformAuthentication(authentication);
            }
            catch (AuthenticationException ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.AuthType = "register";
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception ex)
            {
                //Log this error
                ViewBag.Error = ex.Message;
                ViewBag.AuthType = "register";
                return Json(new { error = ex.Message });
            }
            
            return RedirectToAction("EditPerson", "People");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        { 
            var membership = new MembershipProvider();

            var credentials = new Authentication
            {
                Username = Request["username"],
                Password = Request["loginPassword"]
            };

            try
            {
                membership.PerformAuthentication(credentials);
            }
            catch (AuthenticationException ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.AuthType = "login";
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception ex)
            {
                // Log this error
                ViewBag.Error = ex.Message;
                ViewBag.AuthType = "login";
                return Json(new { error = ex.Message });
            }

            return RedirectToAction("EditPerson", "People");
        }
    }
}