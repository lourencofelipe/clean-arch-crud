using MediatR;

namespace CleanArch.Application.Queries.Product.Query
{
	public record ProductGetByIdQuery(Guid ID ) : IRequest<ProductQueryResponse>;
}
