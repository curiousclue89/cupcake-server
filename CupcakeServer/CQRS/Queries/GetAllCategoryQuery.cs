using CupcakeServer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Queries
{
    public class GetAllCategoryQuery: IRequest<IEnumerable<Category>>
    {
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
        {
            private ApplicationDBContext context;
            public GetAllCategoryQueryHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery query, CancellationToken cancellationToken)
            {
                var categoryList = await context.Categories.ToListAsync();
                return categoryList;
            }
        }
    }
}
