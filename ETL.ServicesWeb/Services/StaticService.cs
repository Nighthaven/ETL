using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;
using ETL.ServicesWeb.Services.Interfaces;
using ETL.ServicesWeb.Static;

namespace ETL.ServicesWeb.Services
{
    internal class StaticService : IStaticService
    {
        private readonly StaticContractClient _client;

        internal StaticService(StaticContractClient pClient)
        {
            if (pClient == null) throw new ArgumentNullException("pClient");

            _client = pClient;
        }

        public IEnumerable<IVehicule> GetVehicules(IAuthentificationToken pToken)
        {
            if (pToken == null) throw new ArgumentNullException("pToken");

            var token = new Token() { Value = pToken.Value };
            var authenticatedRequest = new AuthenticatedRequest() { UnsafeToken = token };
            var response = _client.GetVehicles(authenticatedRequest);

            if (response == null) return Enumerable.Empty<IVehicule>();
            
            return response.ConvertToVehicules().ToList();
        }
    }
}
