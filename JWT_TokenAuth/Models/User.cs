using System.Threading.Tasks;

namespace JWT_TokenAuth.Models
{
    public class User : IUser
    {
        public async Task<bool> Authenticate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return await Task.FromResult(false);

            /* We can check the availability of the user in database here */
            return await Task.FromResult(userName.Trim() == "admin" && password.Trim() == "pass");
        }
    }
}