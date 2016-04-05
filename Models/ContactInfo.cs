using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<SocialMedia> SocialWebSites { get; set; }
    }
}