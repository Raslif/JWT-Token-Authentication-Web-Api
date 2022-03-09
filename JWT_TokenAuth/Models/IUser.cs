using System.Threading.Tasks;

namespace JWT_TokenAuth.Models
{
    public interface IUser
    {
        Task<bool> Authenticate(string userName, string password);
    }
}
