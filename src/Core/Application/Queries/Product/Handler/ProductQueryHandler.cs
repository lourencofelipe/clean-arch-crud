using CleanArch.Application.Queries.Product.Query;
using CleanArch.Application.Repositories;
using MediatR;

namespace CleanArch.Application.Queries.Product.Handler
{
	public sealed class ProductQueryHandler : 
		IRequestHandler<ProductGetByIdQuery, ProductQueryResponse>,
		IRequestHandler<ProductGetAllQuery, List<ProductQueryResponse>>
	{

		private readonly IProductRepository _productRepository;

		public ProductQueryHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public Task<ProductQueryResponse> Handle(ProductGetByIdQuery query, CancellationToken cancellationToken)
		{
			var product = _productRepository.GetById(query.ID);

			var response = new ProductQueryResponse 
			{
				ID = product.ID,
				Name = product.Name,
				Price = product.Price
			};
			return Task.FromResult(response);
		}

		public Task<List<ProductQueryResponse>> Handle(ProductGetAllQuery query, CancellationToken cancellationToken)
		{
			var products = _productRepository.GetAll();

			var response = new List<ProductQueryResponse>();

			foreach (var item in products)
			{
				response.Add(new ProductQueryResponse 
				{
					ID = item.ID,
					Name = item.Name,	
					Price = item.Price
				});
			}

			return Task.FromResult(response);
		}
	}
}
