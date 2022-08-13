using Microsoft.AspNetCore.Identity;

namespace JWTExample.Validators
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName) => CreateIdentityError("DuplicateUserName", $"{userName} kullanıcı adı kullanılmaktadır.");
        public override IdentityError InvalidUserName(string userName) => CreateIdentityError("InvalidUserName", "Geçersiz kullanıcı adı.");
        public override IdentityError DuplicateEmail(string email) => CreateIdentityError("DuplicateEmail", $"{email} başka bir kullanıcı tarafından kullanılmaktadır.");
        public override IdentityError InvalidEmail(string email) => CreateIdentityError("InvalidEmail", "Geçersiz email.");

        private IdentityError CreateIdentityError(string code, string description) => new IdentityError
        {
            Code = code,
            Description = description
        };
    }
}
