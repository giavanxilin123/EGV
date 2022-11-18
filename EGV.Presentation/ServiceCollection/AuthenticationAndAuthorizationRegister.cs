using Microsoft.IdentityModel.Tokens;

namespace EGV.Presentation.ServiceCollection
{
    public static class AuthenticationAndAuthorizationRegister
    {
        public static void AddAuthenticationAndAuthorizationRegister(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => 
                {
                    options.Authority = "https://localhost:5001";
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false, // Validate 
                    };
                });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "SampleAPI");
                });
            });
        }
    }
}