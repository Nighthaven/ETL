using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;

namespace ETL.BusinessLayer.Services.Interfaces
{
    public interface IETLService : IService
    {
        IAuthentificationToken Login(string pUsername, string pPassword);
        void CloseSession(IAuthentificationToken pToken);
        IEnumerable<IVehicule> GetVehicules(IAuthentificationToken pToken);
        IEnumerable<IPosition> GetPositions(IAuthentificationToken pToken, IVehicule pVehicule);
    }
}
