using CupcakeServer.Models;
using CupcakeServer.Models.Items;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Queries
{
    public class GetAllItemQuery: IRequest<IEnumerable<Item>>
    {
        public class GetAllItemQueryHandler : IRequestHandler<GetAllItemQuery, IEnumerable<Item>>
        {
            private ApplicationDBContext context;
            public GetAllItemQueryHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Item>> Handle(GetAllItemQuery query, CancellationToken cancellationToken)
            {
                var itemList = await context.Items.ToListAsync();
                return itemList;
            }
        }
    }
}
