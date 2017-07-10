using System.Collections.Generic;
using ETL.BusinessObjects;

namespace ETL.BusinessLayer.Services.Interfaces
{
    public interface IETLService : IService
    {
        #region Methods

        IAuthentificationToken Login(string pUsername, string pPassword);

        void CloseSession(IAuthentificationToken pToken);

        IEnumerable<IVehicule> GetVehicules(IAuthentificationToken pToken);

        IEnumerable<IPosition> GetPositions(IAuthentificationToken pToken, IVehicule pVehicule);

        #endregion
    }
}
