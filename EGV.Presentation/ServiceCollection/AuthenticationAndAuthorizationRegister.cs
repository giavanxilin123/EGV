using EGV.DataAccessor.Data;
using EGV.DataAccessor.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EGV.Presentation.ServiceCollection
{
    public static class AuthenticationAndAuthorizationRegister
    {
        public static void AddAuthenticationAndAuthorizationRegister(this IServiceCollection services)
        {
            // services.AddIdentity<User, IdentityRole<string>>(options =>
            // {
            //     options.SignIn.RequireConfirmedAccount = false;
            //     options.Password.RequireDigit = false;
            //     options.Password.RequiredLength = 5;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireUppercase = false;
            //     options.Password.RequireLowercase = false;
            // })
            //     .AddEntityFrameworkStores<ApplicationDbContext>()
            //     .AddDefaultTokenProviders();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => 
                {
                    options.Authority = "https://localhost:5001";
                    // options.RequireHttpsMetadata = false;
                    // options.SaveToken = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        // ValidateIssuerSigningKey = true,
                        // ValidateIssuer = true,
                        ValidateAudience = false,
                        // ValidateLifetime = false,
                        // ClockSkew = TimeSpan.Zero,
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