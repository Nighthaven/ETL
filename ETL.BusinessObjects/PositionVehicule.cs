using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessObjects
{
    public class PositionVehicule : IPositionVehicule
    {
        public IVehicule Vehicule { get; set; }
        public DateTime Date { get; set; }
        public long? EventID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReverseGeocoding { get; set; }
        public bool IsReverseGeocodeingCalculatedFlag { get; set; }
        public string MapLink { get; set; }
    }
}
