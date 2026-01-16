using DriverFinder.Core.DependencyInjection;
using DriverFinder.Core.Identity;
using DriverFinder.Core.Services.JwtService;
using DriverFinder.Core.ServicesContracts.IJwtService;
using DriverFinder.Infrastructure.ApplicationContext;
using DriverFinder.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//serilog
//builder.Services.AddSerilog();

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));

})
.AddXmlSerializerFormatters()
.AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

//EF 


builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
    {
        options.Password.RequiredLength = 5;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDBContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDBContext, Guid>>();


//swagger
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
});

//CORS

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins(builder.Configuration.GetSection("AllowOrigins").Get<string[]>())
          .WithHeaders("Authorization", "origin", "accept", "content-type")
        .WithMethods("GET", "POST", "PATCH", "PUT", "DELETE");
    });
});


//JWT

builder.Services.AddAuthentication(JwtBuilder =>
{
    JwtBuilder.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    JwtBuilder.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateLifetime = true,
        RoleClaimType = ClaimTypes.Role
    };
});
builder.Services.AddAuthorization(options => { });

//Repository & Services
builder.Services.AddCore(); //Services
builder.Services.AddInfrastructure(builder.Configuration); //Repositories


builder.Services.AddScoped<IJwtToken, JwtToken>();


var app = builder.Build();

//app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseHsts();

app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
