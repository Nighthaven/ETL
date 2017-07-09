using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessObjects
{
    public interface IPositionVehicule
    {
        IVehicule Vehicule { get; set; } 
        DateTime Date { get; set; }
        long? EventID { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        string ReverseGeocoding { get; set; }
        bool IsReverseGeocodeingCalculatedFlag { get; set; }
        string MapLink { get; set; }
    }
}
