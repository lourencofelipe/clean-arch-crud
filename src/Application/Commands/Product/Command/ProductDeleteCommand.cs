using MediatR;

namespace CleanArch.Application.Commands.Product.Command;
public class ProductDeleteCommand : IRequest<ProductCommandResponse>
{
	public Guid Id { get; set; }
}
