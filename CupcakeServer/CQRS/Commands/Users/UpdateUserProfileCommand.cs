using CupcakeServer.Models;
using MediatR;

namespace CupcakeServer.CQRS.Commands.Users
{
    public class UpdateUserProfileCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string ProfilePhoto { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateUserProfileCommand, int>
        {
            private ApplicationDBContext context;
            public UpdateProductCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
            {
                var profile = context.UserProfile.Where(a => a.UserId == command.UserId).FirstOrDefault();

                if (profile == null)
                {
                    return default;
                }
                else
                {
                    profile.ProfilePhoto = command.ProfilePhoto;
                    await context.SaveChangesAsync();

                    var user = context.Users.Where(a => a.Id == command.UserId).FirstOrDefault();
                    if (user == null)
                    {
                        return default;
                    }
                    user.FullName = command.FullName;
                    user.Email = command.Email;
                    user.PhoneNumber = command.PhoneNumber;
                    user.CPF = command.CPF;

                    await context.SaveChangesAsync();
                    return profile.Id;
                }
            }
        }
    }
}
