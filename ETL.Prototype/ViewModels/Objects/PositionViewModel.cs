using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;

namespace ETL.Prototype.ViewModels
{
    public class PositionViewModel : ViewModelBase
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime Date { get; private set; }
        public int? TripEventID { get; private set; }
        internal IPosition Data { get; private set; }
        public string DateFormatted { get { return Date.ToString("HH:mm:ss");  } }

        public PositionViewModel(IPosition pPosition)
        {
            Latitude = Math.Round(pPosition.Latitude, 6);
            Longitude = Math.Round(pPosition.Longitude, 6);
            Date = pPosition.Date;
            TripEventID = pPosition.TripEventID;
            Data = pPosition;
        }
    }
}
