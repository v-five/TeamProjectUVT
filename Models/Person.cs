using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Person
    {
        public int Id { get; set; }
        public Status CandidateStatus { get; set; }
        public BasicInfo BasicInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Authentication Auth { get; set; }
        public ProfessionalInfo ProfessionalInfo { get; set; }
        public bool IsDeleted { get; set; }
    }
}