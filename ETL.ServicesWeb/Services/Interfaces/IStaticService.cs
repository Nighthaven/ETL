using System.Collections.Generic;
using ETL.BusinessObjects;

namespace ETL.ServicesWeb.Services.Interfaces
{
    public interface IStaticService
    {
        #region Methods

        IEnumerable<IVehicule> GetVehicules(IAuthentificationToken pToken);

        #endregion
    }
}
