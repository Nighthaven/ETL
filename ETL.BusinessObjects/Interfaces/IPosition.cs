using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessObjects
{
    public interface IPosition
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
        DateTime Date { get; set; }
        int? TripEventID { get; set; }
    }
}
