using ETL.ServicesWeb.Services;
using ETL.ServicesWeb.Services.Interfaces;

namespace ETL.ServicesWeb
{
    public static class ServiceFactories
    {
        public static IAuthentificationService CreateAuthentificationService()
        {
            var client = new Authentification.AuthorizationContractClient();
            return new AuthentificationService(client);
        }

        public static IEventService CreateEventService()
        {
            var client = new Event.EventContractClient();
            return new EventService(client);
        }

        public static IStaticService CreateStaticService()
        {
            var client = new Static.StaticContractClient();
            return new StaticService(client);
        }

    }
}
