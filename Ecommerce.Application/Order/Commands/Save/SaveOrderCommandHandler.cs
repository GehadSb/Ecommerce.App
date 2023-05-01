using AutoMapper;
using Ecommerce.Application.Common.Helper.Kafka;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.OrderAggregate.Entity;
using MediatR;
using System.Text.Json;

namespace Ecommerce.Application.Order.Commands.Save
{
    public class SaveOrderCommandHandler : IRequestHandler<SaveOrderCommand, SaveOrderOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ecommerce.Domain.OrderAggregate.Order, long> _orderRepository;
        private readonly IRepository<Ecommerce.Domain.OrderAggregate.Entity.OrderItem, long> _orderItemRepository;
        private readonly IProduceMessage _produceMessage;
        private readonly IMapper _mapper;
        private readonly string topic = "eticket";
        private readonly string bootstrapServers = "localhost:9092";
        public SaveOrderCommandHandler(IUnitOfWork unitOfWork, IRepository<OrderItem, long> orderItemRepository, IRepository<Ecommerce.Domain.OrderAggregate.Order, long> orderRepository, IProduceMessage produceMessage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _produceMessage = produceMessage;
            _mapper = mapper;


        }
        public async Task<SaveOrderOutput> Handle(SaveOrderCommand request, CancellationToken cancellationToken)
        {
            List<Domain.ShoppingCartItemAggregate.ShoppingCartItem> shoppingCartItems = new List<Domain.ShoppingCartItemAggregate.ShoppingCartItem>();
            if (request.ShoppingCartItems.Count > 0 && request.ShoppingCartItems != null)
            {
                shoppingCartItems = new(_mapper.Map<List<Domain.ShoppingCartItemAggregate.ShoppingCartItem>>(request.ShoppingCartItems));
            }

            var order = Ecommerce.Domain.OrderAggregate.Order.Create(request.UserId, shoppingCartItems);
            await _orderRepository.Add(order);
            await _unitOfWork.SaveOrUpdate();
            //kafka
            string message = JsonSerializer.Serialize(order.Id);
            //await _produceMessage.SendOrderRequest(topic, message);

            return new SaveOrderOutput() { Id = order.Id };

        }
    }
}
