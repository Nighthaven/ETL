using ETL.BusinessLayer.Services.Interfaces;
using ETL.BusinessLayer.Services;

namespace ETL.BusinessLayer
{
    public static class ServiceFactories
    {
        public static IETLService CreateETLService()
        {
            var authentificationService = ServicesWeb.ServiceFactories.CreateAuthentificationService();
            var staticService = ServicesWeb.ServiceFactories.CreateStaticService();
            var eventService = ServicesWeb.ServiceFactories.CreateEventService();

            return new ETLService(authentificationService, staticService, eventService);
        }
    }
}
