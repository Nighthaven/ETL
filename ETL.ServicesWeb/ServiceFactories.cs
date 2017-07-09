using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.ServicesWeb.Services.Interfaces;
using ETL.ServicesWeb.Services;

namespace ETL.ServicesWeb
{
    public static class ServiceFactories
    {
        public static IAuthentificationService CreateAuthentificationService()
        {
            var client = new Authentification.AuthorizationContractClient();
            return new AuthentificationService(client);
        }

        public static IReportService CreateReportService()
        {
            var client = new Report.ReportContractClient();
            return new ReportService(client);
        }
    }
}
