using CleanArch.Application.Commands.Product;
using MediatR;

namespace CleanArch.Application.Queries.Product
{
	public class ProductQueryResponse : IRequest<ProductCommandResponse>
	{
		public Guid ID { get; internal set; }
		public string Name { get; internal set; }
		public double Price { get; internal set; }
	}
}
