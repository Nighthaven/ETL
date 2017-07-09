using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessObjects
{
    public interface IVehicule
    {
        int ID { get; set; }
        string Name { get; set; }
        string PlateNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
    }
}
