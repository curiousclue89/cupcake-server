using CupcakeServer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Commands
{
    public class DeleteItemCartCommnand: IRequest<int>
    {

        public int Id { get; set; }
        public class DeleteItemCartCommnandHandler : IRequestHandler<DeleteItemCartCommnand, int>
        {
            private ApplicationDBContext context;
            public DeleteItemCartCommnandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteItemCartCommnand command, CancellationToken cancellationToken)
            {
                var itemcart = await context.ItemCarts.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.ItemCarts.Remove(itemcart);
                await context.SaveChangesAsync();
                return itemcart.Id;
            }
        }
    }
}
