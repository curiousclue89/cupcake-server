using CupcakeServer.Models;
using CupcakeServer.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.CQRS.Queries
{
    public class GetUserProfileQuery: IRequest<UserProfile>
    {
        public int UserId { get; set; }

        public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfile>
        {
            private ApplicationDBContext context;
            public GetUserProfileQueryHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<UserProfile> Handle(GetUserProfileQuery query, CancellationToken cancellationToken)
            {
                var profile = await context.UserProfile.Where(a => a.UserId == query.UserId).FirstOrDefaultAsync();
                return profile;
            }
        }
    }
}
