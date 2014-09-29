namespace VideoStore.CustomerRelations
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseTransport<RabbitMQTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.RijndaelEncryptionService();
            UnobtrusiveMessageConventions.Init(configuration.Conventions());
        }
    }

}
