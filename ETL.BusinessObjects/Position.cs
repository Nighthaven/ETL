using System;

namespace ETL.BusinessObjects
{
    public class Position : IPosition
    {
        #region Properties

        #region Implemented

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int? TripEventID { get; set; }

        #endregion

        #endregion
    }
}
