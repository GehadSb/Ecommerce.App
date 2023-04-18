using Ecommerce.Application.Common.Helper.Kafka;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.OrderAggregate.Entity;
using MediatR;

namespace Ecommerce.Application.Order.Commands.Save
{
    public class SaveOrderCommandHandler : IRequestHandler<SaveOrderCommand, SaveOrderOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ecommerce.Domain.OrderAggregate.Order, long> _orderRepository;
        private readonly IRepository<Ecommerce.Domain.OrderAggregate.Entity.OrderItem, long> _orderItemRepository;
        private readonly IProduceMessage _produceMessage;
        //private readonly string topic = "eticket";
        //private readonly string bootstrapServers = "localhost:9092";
        public SaveOrderCommandHandler(IUnitOfWork unitOfWork, IRepository<OrderItem, long> orderItemRepository, IRepository<Ecommerce.Domain.OrderAggregate.Order, long> orderRepository/*, IProduceMessage produceMessage*/)
        {
            _unitOfWork = unitOfWork;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            //_produceMessage = produceMessage;


        }
        public async Task<SaveOrderOutput> Handle(SaveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Ecommerce.Domain.OrderAggregate.Order.Create(request.UserId, request.ShoppingCartItems);
            await _orderRepository.Add(order);
            await _unitOfWork.SaveOrUpdate();

            //string message = JsonSerializer.Serialize(order.Id);
            //await _produceMessage.SendOrderRequest(topic, message);
            return new SaveOrderOutput() { Id = order.Id };

        }
    }
}
