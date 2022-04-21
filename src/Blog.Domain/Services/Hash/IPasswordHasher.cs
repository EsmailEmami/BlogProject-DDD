namespace Blog.Domain.Services.Hash;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Check(string hash, string password);
}