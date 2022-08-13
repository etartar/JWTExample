using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTExample.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SecuredController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSecuredData()
        {
            return Ok("This Get Secured Data is available only for Authenticated Users.");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PostSecuredData()
        {
            return Ok("This Post Secured Data is available only for Authenticated Users.");
        }

        [HttpPost]
        [Authorize(Policy = "TimeControl")]
        public async Task<IActionResult> PolicySecuredData()
        {
            return Ok("This Policy Secured Data is available only for Authenticated Users.");
        }

        [HttpPost]
        [Authorize(Policy = "UserClaimNamePolicy")]
        public async Task<IActionResult> ClaimSecuredData()
        {
            return Ok("This Claim Secured Data is available only for Authenticated Users.");
        }
    }
}