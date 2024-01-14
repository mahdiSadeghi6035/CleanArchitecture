using BlogManagement.Application.Common.Features;
using Microsoft.AspNetCore.Identity;

namespace BlogManagement.Identity.Common.Services
{
    public static class IdentityResultExtensions
    {
        public static OperationResult ToResult(this IdentityResult result)
        {
            return result.Succeeded ? OperationResult.Succeeded() :
                OperationResult.Failed(result.Errors.Select(d => d.Description).ToArray());
        }
    }
}
