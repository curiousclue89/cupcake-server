using CupcakeServer.Models;
using CupcakeServer.Models.Users;
using MediatR;

namespace CupcakeServer.CQRS.Commands.Users
{
    public class CreateUserProfileCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public string ProfilePhoto { get; set; }

        public class CreateUserProfileCommandHandler: IRequestHandler<CreateUserProfileCommand, int>
        {
            private ApplicationDBContext context;
            public CreateUserProfileCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateUserProfileCommand command, CancellationToken cancellationToken)
            {
                var userProfile = new UserProfile();
                userProfile.UserId = command.UserId;
                userProfile.ProfilePhoto = command.ProfilePhoto;

                context.UserProfile.Add(userProfile);
                await context.SaveChangesAsync();
                return userProfile.Id;
            }
        }
    }
}
