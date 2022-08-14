using JWTIdentityExample.Models;

namespace JWTIdentityExample.Services
{
    public interface IUserService
    {
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
        Task<string> RegisterAsync(RegisterModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
