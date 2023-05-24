using MediatR;

namespace CleanArch.Application.Queries.Product.Query
{
	public record ProductGetAllQuery() : IRequest<List<ProductQueryResponse>>;
}
