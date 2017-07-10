using System;

namespace ETL.BusinessObjects
{
    public interface IPosition
    {
        #region Properties

        double Latitude { get; set; }
        double Longitude { get; set; }
        DateTime Date { get; set; }
        int? TripEventID { get; set; }

        #endregion
    }
}
