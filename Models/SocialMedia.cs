using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public Website Type { get; set; }
        public string Link { get; set; }
    }
}