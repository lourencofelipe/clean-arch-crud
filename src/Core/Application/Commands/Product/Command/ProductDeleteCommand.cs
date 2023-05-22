using MediatR;

namespace CleanArch.Application.Commands.Product.Command
{
	public class ProductDeleteCommand : IRequest<ProductCommandResponse>
	{
		public int Id { get; set; }
	}
}
