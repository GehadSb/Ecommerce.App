namespace Ecommerce.Application.Common.Helper.Kafka
{
    public interface IProduceMessage
    {
        Task<bool> SendOrderRequest(string topic, string message);
    }
}
