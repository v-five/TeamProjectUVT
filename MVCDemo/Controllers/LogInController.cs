using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Membership.Providers;
using MVCDemo.Models;
using System.Security.Authentication;

namespace MVCDemo.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var membership = new MembershipProvider();

            var credentials = new Authentication
            {
                Username = Request["username"],
                Password = Request["password"]
            };

            try
            {
                membership.PerformAuthentication(credentials);
            }
            catch (AuthenticationException ex)
            {
                //TODO: return view with the invalid credentials error
            }

            //TODO: replace with proper version
            return View();
        }
    }
}