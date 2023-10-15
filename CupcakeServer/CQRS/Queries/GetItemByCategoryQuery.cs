using CupcakeServer.Models;
using CupcakeServer.Models.Items;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Queries
{
    public class GetItemByCategoryQuery: IRequest<IEnumerable<Item>>
    {
        public int CategoryId { get; set; }
        public class GetItemByCategoryQueryHandler : IRequestHandler<GetItemByCategoryQuery, IEnumerable<Item>>
        {

            private ApplicationDBContext context;
            public GetItemByCategoryQueryHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Item>> Handle(GetItemByCategoryQuery query, CancellationToken cancellationToken)
            {
                var itemList = await context.Items.Where(i => i.CategoryId == query.CategoryId).ToListAsync();
                return itemList;
            }
        }
    }
}
