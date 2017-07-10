using System;
using System.Collections.Generic;
using System.Linq;

using ETL.BusinessObjects;
using ETL.ServicesWeb.Event;
using ETL.ServicesWeb.Static;

namespace ETL.ServicesWeb
{
    internal static class Extensions
    {
        internal static IEnumerable<IVehicule> ConvertToVehicules(this GetVehiclesResponse pReponse)
        {
            if (pReponse == null || pReponse.Vehicles == null) return Enumerable.Empty<IVehicule>();
            
            return pReponse.Vehicles.Select(x => ConvertToVehicule(x));            
        }

        private static IVehicule ConvertToVehicule(this Vehicle pVehicule)
        {
            if (pVehicule == null) throw new ArgumentNullException("pVehicule");

            return new Vehicule()
            {
                ID = pVehicule.ID,
                Name = pVehicule.Name,
                PlateNumber = pVehicule.PlateNumber,
                Make = pVehicule.BrandName,
                Model = pVehicule.Model
            };
        }

        internal static IEnumerable<IPosition> ConvertToPositions(this GetPositionEventResponse pReponse)
        {
            if (pReponse == null || pReponse.PositionEvents == null) return Enumerable.Empty<IPosition>();

            return pReponse.PositionEvents.Select(x => ConvertToPosition(x));
        }

        private static IPosition ConvertToPosition(this PositionEvent pPosition)
        {
            if (pPosition == null) throw new ArgumentNullException("pPosition");
            
            return new Position()
            {
                Latitude = pPosition.Latitude,
                Longitude = pPosition.Longitude,
                Date = pPosition.GPSDateTime,
                TripEventID = pPosition.TripEventID
            };
        }
    }
}
