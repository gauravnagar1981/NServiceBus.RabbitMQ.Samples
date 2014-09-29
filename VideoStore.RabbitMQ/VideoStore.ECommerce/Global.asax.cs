namespace VideoStore.ECommerce
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using NServiceBus;

    public class MvcApplication : HttpApplication
    {
        public static IBus Bus;

        protected void Application_Start()
        {
            var configuration = new BusConfiguration();

            UnobtrusiveMessageConventions.Init(configuration.Conventions());

            configuration.UseTransport<RabbitMQTransport>();

            configuration.UsePersistence<InMemoryPersistence>();

            configuration.PurgeOnStartup(true);
            configuration.RijndaelEncryptionService();
            configuration.EnableInstallers();

            Bus = NServiceBus.Bus.Create(configuration).Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

    }
}
