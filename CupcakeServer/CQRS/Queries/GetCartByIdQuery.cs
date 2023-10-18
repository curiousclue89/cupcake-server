using CupcakeServer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Queries
{
    public class GetCartByIdQuery: IRequest<Cart>
    {
        public int CartId { get; set; }
        public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Cart>
        {
            private ApplicationDBContext context;
            public GetCartByIdQueryHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<Cart> Handle(GetCartByIdQuery query, CancellationToken cancellationToken)
            {
                var cart = await context.Carts.Where(c => c.Id == query.CartId).FirstOrDefaultAsync();
                cart.ItemCarts = await context.ItemCarts.Where(x => x.CartId == query.CartId).ToListAsync();
                
                return cart;
            }
        }
    }
}
