using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETL.BusinessObjects;
using System.Threading.Tasks;

namespace ETL.ServicesWeb.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<IPosition> GetPositionsForToday(IAuthentificationToken pToken, IVehicule pVehicule);
    }
}
