using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;

namespace ETL.ServicesWeb.Services.Interfaces
{
    public interface IReportService
    {
        IEnumerable<IPositionVehicule> GetPositionsVehiculesForToday(IAuthentificationToken pToken);
    }
}
