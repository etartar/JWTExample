using JWTIdentityExample.Models;
using Microsoft.AspNetCore.Identity;

namespace JWTIdentityExample.Validators
{
    public class CustomUserValidation : IUserValidator<ApplicationUser>
    {
        private readonly List<IdentityError> _errors;

        public CustomUserValidation()
        {
            _errors = new List<IdentityError>();
        }

        public async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            if (int.TryParse(user.UserName[0].ToString(), out int _))
                CreateIdentityError("UserNameNumberStartWith", "Kullanıcı adı sayısal ifadeyle başlayamaz.");
            if (user.UserName.Length < 3 && user.UserName.Length > 25)
                CreateIdentityError("UserNameLength", "Kullanıcı adı 3 - 25 karakter arasında olmalıdır.");
            if (user.Email.Length > 70)
                CreateIdentityError("EmailLength", "Email 70 karakterden fazla olamaz.");
            if (!_errors.Any())
                return await Task.FromResult(IdentityResult.Success);
            else
                return await Task.FromResult(IdentityResult.Failed(_errors.ToArray()));
        }

        private void CreateIdentityError(string code, string description)
        {
            _errors.Add(new IdentityError
            {
                Code = code,
                Description = description
            });
        }
    }
}
