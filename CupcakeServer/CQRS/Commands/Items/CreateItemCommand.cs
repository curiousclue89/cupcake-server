using CupcakeServer.Models.Users;
using CupcakeServer.Models;
using MediatR;
using CupcakeServer.Models.Items;

namespace CupcakeServer.CQRS.Commands.Items
{
    public class CreateItemCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int StockAmount { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
        {
            private ApplicationDBContext context;
            public CreateItemCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateItemCommand command, CancellationToken cancellationToken)
            {
                var item = new Item();
                item.UserId = command.UserId;
                item.CategoryId = command.CategoryId;
                item.Title = command.Title;
                item.StockAmount = command.StockAmount;
                item.Description = command.Description;
                item.Photo = command.Photo;

                context.Items.Add(item);

                await context.SaveChangesAsync();
                return item.Id;
            }
        }
    }
}
