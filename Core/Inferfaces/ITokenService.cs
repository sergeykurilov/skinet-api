using Core.Entities.Identity;

namespace Core.Inferfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}