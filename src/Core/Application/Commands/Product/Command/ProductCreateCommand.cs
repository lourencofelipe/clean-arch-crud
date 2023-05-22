using MediatR;

namespace CleanArch.Application.Commands.Product.Command
{
	public class ProductCreateCommand : IRequest<ProductCommandResponse>
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}
