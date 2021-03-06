﻿using System;
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
                credentials.Password = HashingUtils.Hash(credentials.Password);

                if (context.Person.ToList().Count > 0 && context.Person.Where(x => x.Auth.Username.Equals(credentials.Username) && x.Auth.Password.Equals(credentials.Password)).ToList().Count == 1)
                {
                    _authentication.Username = credentials.Username;
                    _authentication.Password = credentials.Password;
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
                person.Auth.Password = HashingUtils.Hash(person.Auth.Password);

                var cur = context.Person;
                if (context.Person.ToList().Count > 0 && context.Person.Where(x => x.Auth.Username.Equals(person.Auth.Username) || x.ContactInfo.Email.Equals(person.ContactInfo.Email)).ToList().Count > 0)
                {
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
