using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public enum Status
    {
        Rejected = -1,
        PreScreening = 0,
        PostScreening = 1,
        TelephonePhase = 2,
        TehnicalInterview = 3,
        Result = 4
    }
}
