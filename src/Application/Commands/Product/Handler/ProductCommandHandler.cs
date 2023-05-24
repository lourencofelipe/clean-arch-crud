using CleanArch.Application.Commands.Product.Command;
using CleanArch.Application.Repositories;
using MediatR;

namespace CleanArch.Application.Commands.Product.Handler
{
	public sealed class ProductCommandHandler : 
		IRequestHandler<ProductCreateCommand, ProductCommandResponse>,
		IRequestHandler<ProductUpdateCommand, ProductCommandResponse>,
		IRequestHandler<ProductDeleteCommand, ProductCommandResponse>
	{
		private readonly IProductRepository _productRepository;

		public ProductCommandHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		
		public Task<ProductCommandResponse> Handle(ProductCreateCommand command, CancellationToken cancellationToken)
		{
			var entity = new Domain.Entities.Product
			{
				ID = command.ID,
				Name = command.Name,
				Price = command.Price
			};

			_productRepository.CreateProduct(entity);

			var response = new ProductCommandResponse
			{
				ID = entity.ID,
				Name = entity.Name,
				Price = entity.Price
			};

			return Task.FromResult(response);
		}

		public Task<ProductCommandResponse> Handle(ProductUpdateCommand command, CancellationToken cancellationToken)
		{
			var entity = new Domain.Entities.Product
			{
				ID = command.Id,
				Name = command.Name,
				Price = command.Price			
			};
				
			_productRepository.UpdateProduct(entity);

			var response = new ProductCommandResponse
			{
				ID = entity.ID,
				Name = entity.Name,
				Price = entity.Price
			};

			return Task.FromResult(response);
		}

		public Task<ProductCommandResponse> Handle(ProductDeleteCommand command, CancellationToken cancellationToken)
		{
			var entity = new Domain.Entities.Product
			{
				ID = command.Id
			};

			var product = _productRepository.GetById(entity.ID);
			_productRepository.RemoveProduct(product.ID);

			var response = new ProductCommandResponse
			{
				ID = entity.ID,	
				Name = entity.Name,
				Price = entity.Price
			};

			return Task.FromResult(response);
		}
	}
}
