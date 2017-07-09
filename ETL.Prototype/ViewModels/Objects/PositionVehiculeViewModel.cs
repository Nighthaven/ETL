using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;

namespace ETL.Prototype.ViewModels
{
    public class PositionVehiculeViewModel : ViewModelBase
    {
        public VehiculeViewModel Vehicule { get; private set; }
        public long? EventID { get; private set; }
        public DateTime DatePosition { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int VehiculeID { get; private set; }

        public PositionVehiculeViewModel(IPositionVehicule pPosition)
        {
            if (pPosition == null) throw new ArgumentNullException("pPosition");

            DatePosition = pPosition.Date;
            Latitude = pPosition.Latitude;
            Longitude = pPosition.Longitude;
            VehiculeID = pPosition.Vehicule.ID;
            EventID = pPosition.EventID;
            Vehicule = new VehiculeViewModel(pPosition.Vehicule);
        }
    }
}
