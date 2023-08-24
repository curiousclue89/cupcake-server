using CupcakeServer.Models;
using CupcakeServer.Models.Items;
using MediatR;

namespace CupcakeServer.CQRS.Commands.Items
{
    public class CreateItemAttributeCommand : IRequest<int>
    {
        public int ItemId { get; set; }
        public string description { get; set; }

        public class CreateItemAttributeCommandHandler: IRequestHandler<CreateItemAttributeCommand,int>
        {
            private ApplicationDBContext context;
            public CreateItemAttributeCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateItemAttributeCommand command, CancellationToken cancellationToken)
            {
                var itemAttribute = new ItemAttribute();
                itemAttribute.ItemId = command.ItemId;
                itemAttribute.description = command.description;

                context.ItemAttributes.Add(itemAttribute);
                await context.SaveChangesAsync();
                return itemAttribute.Id;
            }
        }
    
    }
}
