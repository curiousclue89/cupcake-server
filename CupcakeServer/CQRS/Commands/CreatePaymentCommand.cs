using CupcakeServer.Models;
using MediatR;

namespace CupcakeServer.CQRS.Commands
{
    public class CreatePaymentCommand: IRequest<int>
    {
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }

        public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand,int>
        {
            private ApplicationDBContext context;
            public CreatePaymentCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
            {
                var payment = new Payment();
                payment.OrderId = command.OrderId;
                payment.PaymentDate = command.PaymentDate;
                payment.PaymentMethod = command.PaymentMethod;
                payment.Price = command.Price;
                payment.Status = command.Status;

                context.Payments.Add(payment);
                await context.SaveChangesAsync();
                return payment.Id;

            }
        }

    }
}
