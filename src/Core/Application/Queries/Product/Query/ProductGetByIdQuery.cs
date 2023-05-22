using MediatR;

namespace CleanArch.Application.Queries.Product.Query
{
	public class ProductGetByIdQuery : IRequest<ProductQueryResponse>
	{
		public int ID { get; set; }
	}
}
