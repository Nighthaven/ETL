using System;
using System.Collections.Generic;
using System.Linq;

using ETL.BusinessObjects;
using ETL.ServicesWeb.Static;
using ETL.ServicesWeb.Services.Interfaces;

namespace ETL.ServicesWeb.Services
{
    internal class StaticService : IStaticService
    {
        #region Fields

        private readonly StaticContractClient _client;

        #endregion

        #region Constructors

        internal StaticService(StaticContractClient pClient)
        {
            if (pClient == null) throw new ArgumentNullException("pClient");

            _client = pClient;
        }

        #endregion

        #region Methods

        #region Implemented

        public IEnumerable<IVehicule> GetVehicules(IAuthentificationToken pToken)
        {
            if (pToken == null) throw new ArgumentNullException("pToken");

            var token = new Token() { Value = pToken.Value };
            var authenticatedRequest = new AuthenticatedRequest() { UnsafeToken = token };
            var response = _client.GetVehicles(authenticatedRequest);

            if (response == null) return Enumerable.Empty<IVehicule>();

            return response.ConvertToVehicules().ToList();
        }

        #endregion

        #endregion
    }
}