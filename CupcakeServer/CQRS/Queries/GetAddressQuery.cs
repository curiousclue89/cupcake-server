using CupcakeServer.Models;
using CupcakeServer.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Queries
{
    public class GetAddressQuery: IRequest<IEnumerable<UserAddress>>
    {
        public int UserId { get; set; }

        public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, IEnumerable<UserAddress>>
        {
            private ApplicationDBContext context;
            public GetAddressQueryHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<UserAddress>> Handle(GetAddressQuery query, CancellationToken cancellationToken)
            {
                var addresses = await context.UserAddress.Where(a => a.UserId == query.UserId).ToListAsync();
                return addresses;
            }
        }
    }
}
