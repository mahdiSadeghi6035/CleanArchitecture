using BlogManagement.Application.Common.Features;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BlogManagement.Identity.Common.Services;

public static class SignInResultExtensions
{
    public static OperationResult ToResult(this SignInResult result)
    {
        if (result.Succeeded)
        {
            return OperationResult.Succeeded();
        }

        if (result.IsLockedOut)
        {
            return OperationResult.Failed("Your account has been locked due to multiple unsuccessful login attempts.");
        }

        if (result.RequiresTwoFactor)
        {
            return OperationResult.Failed("Two-factor authentication is required for login.");
        }

        return OperationResult.Failed("Login was unsuccessful. Please try again.");
    }
}
