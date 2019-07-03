namespace Ecooperation_backend.Helpers
{
    public interface ITokenGenerator
    {
        string GenerateToken(long userId);
    }
}
