using CupcakeServer.Models;
using CupcakeServer.Models.Users;
using MediatR;

namespace CupcakeServer.CQRS.Commands
{
    public class CreateDeliveryCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, int>
        {
            private ApplicationDBContext context;
            public CreateDeliveryCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateDeliveryCommand command, CancellationToken cancellationToken)
            {
                var delivery = new Delivery();
                delivery.UserId = command.UserId;
                delivery.OrderId = command.OrderId;
                delivery.Status = command.Status;
                delivery.Departure = command.Departure;
                delivery.Arrival = command.Arrival;

                context.Deliveries.Add(delivery);
                await context.SaveChangesAsync();
                return delivery.Id;
            }
        }
    }
}
