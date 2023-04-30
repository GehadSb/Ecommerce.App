namespace Ecommerce.API.Helper.Kafka
{
    public interface IProduceMessage
    {
        Task<bool> SendOrderRequest(string topic, string message);
    }
}
