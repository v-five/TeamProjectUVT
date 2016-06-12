using System;
using System.Linq;
using Membership.Utils;
using MVCDemo.Models;
using Database;
using System.Web;
using System.Security.Authentication;

namespace Membership.Providers
{
    public class MembershipProvider
    {
        private Authentication _authentication
        {
            get
            {
                if (HttpContext.Current.Session["Authentication"] == null)
                {
                    return new Authentication();
                }
                return HttpContext.Current.Session["Authentication"] as Authentication;
            }
        }

        public void PerformAuthentication(Authentication credentials)
        {
            try
            {
                var context = new DemoContext();

                if (context.Person.ToList().Count > 0 && context.Person.Where(x => (x.Auth.Username.Equals(credentials.Username) || x.ContactInfo.Email.Equals(credentials.Username))  && x.Auth.Password.Equals(credentials.Password)).ToList().Count == 1)
                {
                    _authentication.Username = credentials.Username;
                    _authentication.Password = credentials.Password;
                    HttpContext.Current.Session["Authentication"] = new Authentication
                    {
                        Username = credentials.Username,
                        Password = credentials.Password
                    };
                }
                else
                {
                    throw new AuthenticationException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PerformRegistration(Person person)
        {
            try
            {
                var context = new DemoContext();

                var cur = context.Person;
                if (context.Person.Where(x => x.Auth.Username.Equals(person.Auth.Username)).ToList().Count > 0)
                {   
                    var cacat = context.Person.Where(x => x.Auth.Username.Equals(person.Auth.Username)).ToList();
                    throw new AuthenticationException();
                }

                context.Person.Add(person);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserInformation(Person person)
        {
            try
            {
                person.Auth = _authentication;
                person.ContactInfo.Email = _authentication.Username;
                var context = new DemoContext();
                var existingRecord = context.Person.SingleOrDefault(x => x.Auth.Username == _authentication.Username);
                
                if (context.Person.ToList().Count < 1 || existingRecord == null)
                {
                    throw new AuthenticationException();
                }

                existingRecord.BasicInfo = person.BasicInfo;
                existingRecord.ContactInfo = person.ContactInfo;
                        
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAuthenticated()
        {
            if (string.IsNullOrEmpty(_authentication.Username) || string.IsNullOrEmpty(_authentication.Password))
            {
                return false;
            }

            return true;
        }
    }
}
