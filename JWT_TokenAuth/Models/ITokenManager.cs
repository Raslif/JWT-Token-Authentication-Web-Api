using System.Security.Claims;
using System.Threading.Tasks;

namespace JWT_TokenAuth.Models
{
    public interface ITokenManager
    {
        Task<Token> GenerateToken();
        Task<bool> VerifyToken(string token);
    }
}
