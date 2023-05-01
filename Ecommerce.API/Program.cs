using Ecommerce.API;
using Ecommerce.API.Helper.Cart;
using Ecommerce.API.Middleware;
using Ecommerce.Application.Common.Exceptions;
using Ecommerce.Application.DependencyInjection;
using Ecommerce.Application.Movie.Services;
using Ecommerce.Domain.Common;
using Ecommerce.Infrastructure.DependencyInjection;
using Ecommerce.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///
var configuration = builder.Configuration;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
    .AddJsonFile("secrets/appsettings.secrets.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
//register it to for serlize
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
//register fluent validation
builder.Services.AddControllers()
.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(ValidationException)));
//register service
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddApplicationServices(configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddScoped<Ecommerce.Application.Common.Helper.Kafka.IProduceMessage, Ecommerce.Application.Common.Helper.Kafka.ProduceMessage>();
builder.Services.AddTransient<ExceptionHandlerMiddleware>();
///

//keycloak
//rgister auth
builder.Services.RegisterSwaggerAuthentication();

IdentityModelEventSource.ShowPII = true;
//var authenticationOptions = new KeycloakAuthenticationOptions
//{
//    AuthServerUrl = "http://localhost:8088/",
//    Realm = "Test",
//    Resource = "test-client",
//};

//var authenticationOptions = configuration
//    .GetSection(KeycloakAuthenticationOptions.Section)
//    .Get<KeycloakAuthenticationOptions>();
//builder.Services.AddKeycloakAuthentication(authenticationOptions);
//var host = builder.Host;
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
//    o.Authority = configuration["Jwt:httpx``s://localhost:8080/auth/realms/TESTEco"];//https://localhost:8080/auth/realms/TESTEco
//    o.Audience = configuration["Jwt:demo-app"];//demo-app
//    o.Events = new JwtBearerEvents()
//    {
//        OnAuthenticationFailed = c =>
//        {
//            c.NoResult();

//            c.Response.StatusCode = 500;
//            c.Response.ContentType = "text/plain";
//            //if (Environment.IsDevelopment())
//            //{
//            //    return c.Response.WriteAsync(c.Exception.ToString());
//            //}
//            return c.Response.WriteAsync("An error occured processing your authentication.");
//        }
//    };
//});




builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.Authority = "http://localhost:8080/auth/realms/Ecommerce/";
    o.Audience = "TEST";
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudiences = new string[] { "Ecommerce", "account", "TEST" }
    };
    o.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = c =>
        {
            c.NoResult();
            c.Response.StatusCode = 500;
            c.Response.ContentType = "application/json";
            return c.Response.WriteAsync(c.Exception.ToString());
        }
    };
    o.RequireHttpsMetadata = false;
    o.Validate();
    o.SaveToken = true;
});

//


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

////app.UseHttpsRedirection();
app.UseSession();

// app.UseAuthorization();


//========= Exception Handler ===========
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();


app.UseAuthentication();
app.UseAuthorization();
//keycloack
//app.MapGet("/", (ClaimsPrincipal user) =>
//{
//    app.Logger.LogInformation(user.Identity.Name);
//}).RequireAuthorization();

//
app.Run();
