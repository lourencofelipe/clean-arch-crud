using CleanArch.Application.Interfaces.Authentication;
using CleanArch.Application.Commands.User.Command;
using CleanArch.Domain.Exceptions;
using MediatR;

namespace CleanArch.Application.Commands.User.Handler
{
	public class UserCommandHandler : 
		IRequestHandler<UserCreateCommand, UserResponse>,
		IRequestHandler<UserLoginCommand, string>

	{
		private readonly IAuthentication _authentication;
		public static Domain.Entities.User user = new Domain.Entities.User();

		public UserCommandHandler(IAuthentication authentication)
		{
			_authentication = authentication;
		}

		public Task<UserResponse> Handle(UserCreateCommand command, CancellationToken cancellationToken)
		{
			_authentication.CreatePasswordHash(command.Password, out byte[] passwordHash, out byte[] passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;
			user.Username = command.Username;	

			var response = new UserResponse()
			{
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				Username = user.Username,
			};

			return Task.FromResult(response);
		}

		public Task<string> Handle(UserLoginCommand command, CancellationToken cancellationToken)
		{

			if (user.Username != command.Username)
				throw new UserException("User not found.");

			if (!_authentication.VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt))
				throw new UserException("Wrong password.");

			string token = _authentication.CreateToken(user);

			return Task.FromResult(token);
		}
	}
}
