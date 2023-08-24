using CupcakeServer.Models.Users;
using CupcakeServer.Models;
using MediatR;

namespace CupcakeServer.CQRS.Commands
{
    public class CreateOrderCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, int>
        {
            private ApplicationDBContext context;
            public CreateOrderCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = new Order();
                order.UserId = command.UserId;
                order.Description = command.Description;
                order.OrderDate = command.OrderDate;
                order.Status = command.Status;

                context.Orders.Add(order);

                command.OrderItems.ForEach(o =>
                {
                    var orderItem = new OrderItem();
                    orderItem.OrderId = order.Id;
                    orderItem.ItemId = o.ItemId;
                    orderItem.Quantity = o.Quantity;

                    context.OrderItem.Add(orderItem);
                });

                await context.SaveChangesAsync();
                return order.Id;
            }
        }
    }
}
