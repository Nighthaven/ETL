using System.Collections.Generic;
using ETL.BusinessObjects;

namespace ETL.ServicesWeb.Services.Interfaces
{
    public interface IEventService
    {
        #region Methods

        IEnumerable<IPosition> GetPositionsForToday(IAuthentificationToken pToken, IVehicule pVehicule);

        #endregion
    }
}
