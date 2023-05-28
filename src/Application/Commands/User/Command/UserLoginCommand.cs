using MediatR;

namespace CleanArch.Application.Commands.User.Command
{
	public record UserLoginCommand(string Username, string Password) : IRequest<string>;
}
