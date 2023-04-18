namespace Ecommerce.UI.Helper.Kafka
{
    public interface IProduceMessage
    {
        Task<bool> SendOrderRequest(string topic, string message);
    }
}
