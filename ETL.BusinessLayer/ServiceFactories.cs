using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessLayer.Services.Interfaces;
using ETL.BusinessLayer.Services;

namespace ETL.BusinessLayer
{
    public static class ServiceFactories
    {
        public static IETLService CreateETLService()
        {
            var authentificationService = ServicesWeb.ServiceFactories.CreateAuthentificationService();
            return new ETLService(authentificationService);
        }
    }
}
