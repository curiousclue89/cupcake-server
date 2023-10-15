using CupcakeServer.Models.Users;
using CupcakeServer.Models;
using MediatR;

namespace CupcakeServer.CQRS.Commands
{
    public class CreateCartCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public double Price { get; set; }
        public List<ItemCart> ItemCarts { get; set; }

        public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
        {
            private ApplicationDBContext context;
            public CreateCartCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateCartCommand command, CancellationToken cancellationToken)
            {
                var cart = new Cart();
                cart.UserId = command.UserId;
                cart.Price = command.Price;

                context.Carts.Add(cart);

                command.ItemCarts.ForEach(o =>
                {
                    var itemCart = new ItemCart();
                    itemCart.CartId = cart.Id;
                    itemCart.ItemId = o.ItemId;
                    itemCart.Quantity = o.Quantity;

                    context.ItemCarts.Add(itemCart);
                });

                await context.SaveChangesAsync();
                return cart.Id;
            }
        }

    }
}

