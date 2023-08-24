using CupcakeServer.Models.Users;
using CupcakeServer.Models;
using MediatR;

namespace CupcakeServer.CQRS.Commands.Users
{
    public class CreateUserCommand: IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public UserCredential credential { get; set; }

        public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, int>
        {
            private ApplicationDBContext context;
            public CreateUserCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new User();
                user.FullName = command.FullName;
                user.Email = command.Email;
                user.Password = command.Password;
                user.PhoneNumber = command.PhoneNumber;
                user.CPF = command.CPF;
                user.credential = command.credential;

                context.Users.Add(user);
                await context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}
