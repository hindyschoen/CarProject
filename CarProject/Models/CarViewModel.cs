using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarProject.Models
{
    public class CarViewModel
    {
       public List<Car> Cars = new();
        public bool Sort { get; set; }
    }
}
