using CupcakeServer.Models;
using CupcakeServer.Models.Users;
using MediatR;

namespace CupcakeServer.CQRS.Commands.Users
{
    public class CreateUserAddressCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public string Street { get; set; }
        public int NumberStreet { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        
        public class CreateUserAddressCommandHandler: IRequestHandler<CreateUserAddressCommand, int>
        {
            private ApplicationDBContext context;
            public CreateUserAddressCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateUserAddressCommand command, CancellationToken cancellationToken)
            {
                var userAddress = new UserAddress();
                userAddress.Street = command.Street;
                userAddress.UserId = command.UserId;
                userAddress.NumberStreet = command.NumberStreet;
                userAddress.City = command.City;
                userAddress.PostalCode = command.PostalCode;
                userAddress.State = command.State;

                context.UserAddress.Add(userAddress);
                await context.SaveChangesAsync();
                return userAddress.Id;
            }
        }
    }
}
