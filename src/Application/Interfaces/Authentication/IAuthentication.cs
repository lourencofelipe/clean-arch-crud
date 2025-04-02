using CleanArch.Domain.Entities;

namespace CleanArch.Application.Interfaces.Authentication;
public interface IAuthentication
{
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

    public string CreateToken(User user);
}
