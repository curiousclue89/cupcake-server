using CupcakeServer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Commands
{
    public class UpdateCartCommand: IRequest<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public List<ItemCart> ItemCarts { get; set; }

        public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, int>
        {
            private ApplicationDBContext context;
            public UpdateCartCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
            {
                var cart = context.Carts.Where(a => a.Id == command.Id).FirstOrDefault();

                if (cart == null)
                {
                    return default;
                }
                else
                {
                    cart.Price = command.Price;
                    cart.ItemCarts = command.ItemCarts;
                    var itemCarts = context.ItemCarts.Where(it => it.CartId == command.Id).ToListAsync();
                    itemCarts.Result.ForEach( it =>
                    {
                        it.Quantity = command.ItemCarts.Where(i => i.Id == it.Id).FirstOrDefault().Quantity;
                    });
                    await context.SaveChangesAsync();
                    return cart.Id;
                }
            }
        }
    }
}
