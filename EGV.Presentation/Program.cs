using System.Net;
using EGV.Business;
using EGV.DataAccessor;
using EGV.DataAccessor.Entities;
using EGV.Presentation.ServiceCollection;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthenticationAndAuthorizationRegister();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDataAccessorLayer(builder.Configuration);
builder.Services.AddBusinessLayer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSpaStaticFiles(configuration =>
// {
//     configuration.RootPath = "adminweb/build";
// });

builder.Services.AddSwaggerRegister();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        builder =>
        {
            //https://asset-management-team3-group1.azurewebsites.net/
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthUsePkce();
    });
    IdentityModelEventSource.ShowPII = true;
    ServicePointManager.Expect100Continue = true;
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
    | SecurityProtocolType.Tls11
    | SecurityProtocolType.Tls12;
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ApiScope");

// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "adminweb";

//     if (app.Environment.IsDevelopment())
//     {
//         spa.UseReactDevelopmentServer(npmScript: "start");
//     }
// });

app.Run();
