using System;
using ETL.BusinessObjects;

namespace ETL.Prototype.ViewModels
{
    public class VehiculeViewModel : ViewModelBase
    {
        #region Properties

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string PlateNumber { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string StringToShow { get { return string.Format("{0} - {1}", Name, PlateNumber); } }
        internal IVehicule Data { get; private set; }

        #endregion

        #region Constructors

        public VehiculeViewModel(IVehicule pVehicule)
        {
            if (pVehicule == null) throw new ArgumentNullException("pVehicule");

            ID = pVehicule.ID;
            Name = pVehicule.Name;
            PlateNumber = pVehicule.PlateNumber;
            Make = pVehicule.Make;
            Model = pVehicule.Model;
            Data = pVehicule;
        }

        #endregion
    }
}
