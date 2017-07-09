using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;
using ETL.ServicesWeb.Report;

namespace ETL.ServicesWeb
{
    internal static class Extensions
    {
        internal static IEnumerable<IPositionVehicule> ConvertToPositionsVehicules(this ReportResponseBaseOfPositionByVehicleReportGridView pReponse)
        {
            if (pReponse == null || pReponse.Views == null) return Enumerable.Empty<IPositionVehicule>();

            var vehiculesPositions = pReponse.Views.Select(x => new { Vehicule = x.Vehicle, Position = x.Position, Date = x.Date }).ToList();

            return vehiculesPositions.Select(x => ConvertToPositionVehicule(x.Position, x.Vehicule, x.Date));            
        }

        private static IVehicule ConvertToVehicule(this PositionByVehicleReportGridViewVehicle pVehicule)
        {
            if (pVehicule == null) throw new ArgumentNullException("pVehicule");

            return new Vehicule()
            {
                ID = pVehicule.VehicleID,
                Name = pVehicule.VehicleName,
                PlateNumber = pVehicule.PlateNumber,
                Make = pVehicule.VehicleMake,
                Model = pVehicule.VehicleModel
            };
        }

        private static DateTime ConvertToDateTime(this PositionByVehicleReportGridViewDate pDateTime)
        {
            if (pDateTime == null) throw new ArgumentNullException("pDateTime");

            return pDateTime.DateTime;
        }

        private static IPositionVehicule ConvertToPositionVehicule(PositionByVehicleReportGridViewPosition pPosition, PositionByVehicleReportGridViewVehicle pVehicule, PositionByVehicleReportGridViewDate pDate)
        {
            if (pPosition == null) throw new ArgumentNullException("pPosition");
            if (pVehicule == null) throw new ArgumentNullException("pVehicule");
            if (pDate == null) throw new ArgumentNullException("pDate");

            var vehicule = pVehicule.ConvertToVehicule();
            var datetime = pDate.ConvertToDateTime();

            return new PositionVehicule()
            {
                Date = datetime,
                Vehicule = vehicule,
                EventID = pPosition.PositionEventID,
                IsReverseGeocodeingCalculatedFlag = pPosition.IsReverseGeocodingCalculatedFlag,
                Latitude = pPosition.Latitude,
                Longitude = pPosition.Longitude,
                MapLink = pPosition.MapLink,
                ReverseGeocoding = pPosition.ReverseGeocoding
            };
        }
    }
}
