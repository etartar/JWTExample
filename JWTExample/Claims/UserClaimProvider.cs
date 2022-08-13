using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace JWTExample.Claims
{
    public class UserClaimProvider : IClaimsTransformation
    {
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
            Claim claim = null;

            if (principal.HasClaim(x => x.Type.Equals("username")))
            {
                claim = new Claim("username", identity.Name);
                identity.AddClaim(claim);
            }

            if (principal.HasClaim(x => x.Type.Equals("logintime")))
            {
                claim = new Claim("logintime", DateTime.Now.ToString());
                identity.AddClaim(claim);
            }

            return await Task.FromResult(principal);
        }
    }
}
