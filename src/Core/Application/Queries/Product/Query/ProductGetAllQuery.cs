using MediatR;

namespace CleanArch.Application.Queries.Product.Query
{
	public class ProductGetAllQuery : IRequest<List<ProductQueryResponse>>
	{
	}
}
