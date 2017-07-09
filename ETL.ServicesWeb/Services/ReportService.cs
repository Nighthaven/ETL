using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.ServicesWeb.Services.Interfaces;
using ETL.ServicesWeb.Report;
using ETL.BusinessObjects;

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

        public IEnumerable<IPositionVehicule> GetPositionsVehiculesForToday(IAuthentificationToken pToken)
        {
            if (pToken == null) throw new ArgumentNullException("pToken");

            var now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, DateTimeKind.Utc);

            var token = new Token() { Value = pToken.Value };
            var reportRequest = new ReportRequest() { StartDateTime = startDate, EndDateTime = endDate, UnsafeToken = token };
            reportRequest.Datas = new ReportFilter[0];
            reportRequest.Groupings = new GroupingByType[0];

            var reportResponse = _client.GetPositions(reportRequest);

            if (reportResponse == null) return Enumerable.Empty<IPositionVehicule>();

            return reportResponse.ConvertToPositionsVehicules();
        }
    }
}
