using CupcakeServer.Models.Users;
using CupcakeServer.Models;
using MediatR;

namespace CupcakeServer.CQRS.Commands.Users
{
    public class CreateUserCardCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public string Number { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CCV { get; set; }

        public class CreateUserCardCommandHandler : IRequestHandler<CreateUserCardCommand, int>
        {
            private ApplicationDBContext context;
            public CreateUserCardCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateUserCardCommand command, CancellationToken cancellationToken)
            {
                var userCard = new UserCard();
                userCard.UserId = command.UserId;
                userCard.Number = command.Number;
                userCard.ExpirationDate = command.ExpirationDate;
                userCard.CCV = command.CCV;

                context.UserCard.Add(userCard);
                await context.SaveChangesAsync();
                return userCard.Id;
            }
        }
    }
}
