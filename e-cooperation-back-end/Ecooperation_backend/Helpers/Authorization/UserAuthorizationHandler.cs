using Ecooperation_backend.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Ecooperation_backend.Helpers.Authorization
{
    public class UserAuthorizationHandler : AuthorizationHandler<SameAuthorRequirement, User>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameAuthorRequirement requirement, User resource)
        {
            if (context.User.Identity.Name == resource.Id.ToString())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
