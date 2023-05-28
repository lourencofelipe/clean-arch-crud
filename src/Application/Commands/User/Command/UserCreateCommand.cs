using MediatR;

namespace CleanArch.Application.Commands.User.Command
{
	public record UserCreateCommand(string Username, string Password) : IRequest<UserResponse>;
}
