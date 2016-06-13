using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public bool IsFlat { get; set; }
        public string Entrance { get; set; }
        public string FlatNumber { get; set; }
    }
}