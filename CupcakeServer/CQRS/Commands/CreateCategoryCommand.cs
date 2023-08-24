using CupcakeServer.Models;
using MediatR;

namespace CupcakeServer.CQRS.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Description { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private ApplicationDBContext context;
            public CreateCategoryCommandHandler(ApplicationDBContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
            {
                var category = new Category();
                category.Description = command.Description;

                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return category.Id;
            }
        }
    }
}
