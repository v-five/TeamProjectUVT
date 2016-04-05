using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class ProfessionalInfo
    {
        public int Id { get; set; }
        public string LastDegreeEarned { get; set; }
        public int YearsOfExperience { get; set; }
        public Range ExpectedSalary { get; set; }
        public int CurrentSalary { get; set; }
        public string CurrentJobTitle { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

    }
}