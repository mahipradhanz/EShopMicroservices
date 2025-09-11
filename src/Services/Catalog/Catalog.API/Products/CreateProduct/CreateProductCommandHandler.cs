namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, decimal Price, string ImagesFile)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler (IDocumentSession session): ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Implementation to create a product would go here.
            // Create product entity from command object

            // Return the CreateProductResult
            var product = new Model.Product
            {
                Id = new Guid(),
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Price = command.Price,
                ImagesFile = command.ImagesFile
            };
            // Save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(product.Id);
        }
    }
}
