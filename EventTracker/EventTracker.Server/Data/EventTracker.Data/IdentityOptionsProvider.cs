using Microsoft.AspNetCore.Identity;

namespace EventTracker.Data
{
    public static class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options)
        {
            // Set options for Password
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;

            // Set options for SignIn
            options.SignIn.RequireConfirmedEmail = false;
        }
    }
}
