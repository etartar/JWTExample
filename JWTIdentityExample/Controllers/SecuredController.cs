using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTIdentityExample.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuredController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSecuredData()
        {
            return Ok("This Get Secured Data is available only for Authenticated Users.");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult PostSecuredData()
        {
            return Ok("This Post Secured Data is available only for Authenticated Users.");
        }

        //[HttpPost]
        //[Authorize(Policy = "TimeControl")]
        //public IActionResult PolicySecuredData()
        //{
        //    return Ok("This Policy Secured Data is available only for Authenticated Users.");
        //}

        //[HttpPost]
        //[Authorize(Policy = "UserClaimNamePolicy")]
        //public IActionResult ClaimSecuredData()
        //{
        //    return Ok("This Claim Secured Data is available only for Authenticated Users.");
        //}
    }
}