using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessObjects
{
    public class Vehicule : IVehicule
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
