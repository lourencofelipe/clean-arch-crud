namespace CleanArch.Application.Commands.User
{
	public class UserResponse
	{
		public string Username { get; set; } = string.Empty;
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
	}
}
