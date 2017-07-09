using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;

namespace ETL.ServicesWeb.Services.Interfaces
{
    public interface IStaticService
    {
        IEnumerable<IVehicule> GetVehicules(IAuthentificationToken pToken);
    }
}
