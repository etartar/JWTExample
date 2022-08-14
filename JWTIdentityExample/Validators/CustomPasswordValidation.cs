using JWTIdentityExample.Models;
using Microsoft.AspNetCore.Identity;

namespace JWTIdentityExample.Validators
{
    public class CustomPasswordValidation : IPasswordValidator<ApplicationUser>
    {
        private readonly List<IdentityError> _errors;

        public CustomPasswordValidation()
        {
            _errors = new List<IdentityError>();
        }

        public async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            if (password.Length < 5) CreateIdentityError("PasswordLength", "Lütfen şifreyi en az 5 karakter giriniz.");
            if (password.ToLower().Contains(user.UserName.ToLower())) CreateIdentityError("PasswordContainsUserName", "Lüften şifre içerisinde kullanıcı adını yazmayınız.");
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
