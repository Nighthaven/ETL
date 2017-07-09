using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.ServicesWeb.Services.Interfaces;
using ETL.ServicesWeb.Report;

namespace ETL.ServicesWeb.Services
{
    internal class ReportService : IReportService
    {
        private readonly ReportContractClient _client;

        internal ReportService(ReportContractClient pClient)
        {
            if (pClient == null) throw new ArgumentNullException("pClient");

            _client = pClient;
        }

        public void salut()
        {
        }
        
    }
}
