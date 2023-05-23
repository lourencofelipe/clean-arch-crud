using MediatR;

namespace CleanArch.Application.Commands.Product.Command
{
	public class ProductUpdateCommand : IRequest<ProductCommandResponse>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}
