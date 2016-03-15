using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreeAddress { get; set; }
        public int HouseNumber { get; set; }
        public int AppartmentNumber { get; set; }
        public AddressType Type { get; set; }
    }
}
