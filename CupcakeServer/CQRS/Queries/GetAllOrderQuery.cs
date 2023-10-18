using CupcakeServer.Models.Items;
using CupcakeServer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<Order>>
    {
        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Order>>
        {
            private ApplicationDBContext context;
            public GetAllOrderQueryHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Order>> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
            {
                var orderList = await context.Orders.ToListAsync();
                orderList.ForEach(async o =>
                {
                    List<OrderItem> orderItemList;
                    orderItemList = await context.OrderItem.Where(oi => oi.OrderId == o.Id).ToListAsync();
                    o.OrderItems = orderItemList;
                });
                return orderList;
            }
        }
    }
}
