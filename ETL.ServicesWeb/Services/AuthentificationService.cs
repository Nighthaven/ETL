using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;
using ETL.ServicesWeb.Services.Interfaces;
using ETL.ServicesWeb.Authentification;

namespace ETL.ServicesWeb.Services
{
    internal class AuthentificationService : IAuthentificationService
    {
        private readonly AuthorizationContractClient _client;

        internal AuthentificationService(AuthorizationContractClient pClient)
        {
            if (pClient == null) throw new ArgumentNullException("pClient");

            _client = pClient;
        }

        public bool Close(IAuthentificationToken pToken)
        {
            if (pToken == null) throw new ArgumentNullException("pToken");

            var token = new Token() { Value = pToken.Value };
            var authenticateRequest = new AuthenticatedRequest() { UnsafeToken = token };
            _client.CloseSession(authenticateRequest);
            
            return true;
        }

        public IAuthentificationToken Login(string pUsername, string pPassword)
        {
            if (string.IsNullOrWhiteSpace(pUsername)) throw new ArgumentNullException("pUsername");
            if (string.IsNullOrWhiteSpace(pPassword)) throw new ArgumentNullException("pPassword");

            var openSessionRequest = new OpenSessionRequest() { Username = pUsername, Password = pPassword };
            var openSessionResponse = _client.OpenSession(openSessionRequest);

            if (!openSessionResponse.IsAuthenticated) { return null; }

            return new AuthentificationToken() { Value = openSessionResponse.Token.Value, FleetOwnerID = openSessionResponse.FleetOwnerID };
        }
    }
}
