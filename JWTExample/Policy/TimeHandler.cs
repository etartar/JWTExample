using Microsoft.AspNetCore.Authorization;

namespace JWTExample.Policy
{
    public class TimeHandler : AuthorizationHandler<TimeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TimeRequirement requirement)
        {
            if (DateTime.Now.Minute >= 40 && DateTime.Now.Minute < 50)
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}
