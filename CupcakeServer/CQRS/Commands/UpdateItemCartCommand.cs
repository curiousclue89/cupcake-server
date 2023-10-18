using CupcakeServer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Commands
{
    public class UpdateItemCartCommand: IRequest<int>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public class UpdateItemCartCommandHandler : IRequestHandler<UpdateItemCartCommand, int>
        {
            private ApplicationDBContext context;
            public UpdateItemCartCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateItemCartCommand command, CancellationToken cancellationToken)
            {
                var itemCart = context.ItemCarts.Where(it => it.Id == command.Id).FirstOrDefaultAsync();

                if (itemCart == null)
                {
                    return default;
                }
                else
                {
                    itemCart.Result.Quantity = command.Quantity;
                    await context.SaveChangesAsync();
                    return itemCart.Id;
                }
            }
        }
    }
}
