using Ecommerce.Application.Common.Helper.Kafka;
using Ecommerce.Application.DependencyInjection;
using Ecommerce.Application.Movie.Services;
using Ecommerce.Domain.Common;
using Ecommerce.Infrastructure.DependencyInjection;
using Ecommerce.Infrastructure.Persistence.context;
using Ecommerce.Infrastructure.Persistence.Repositories;
using Ecommerce.UI.Extentions.Handler;
using Ecommerce.UI.Helper.Cart;
using Ecommerce.UI.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
    .AddJsonFile("secrets/appsettings.secrets.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllersWithViews();

///
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
builder.Services.AddScoped<IProduceMessage, ProduceMessage>();
builder.Services.AddTransient<ExceptionHandlerMiddleware>();
//kafka

//builder.Services.AddSingleton<IHostedService, ConsumerBackgroundServiceOderComplete>();

//
//KeyClock
var host = builder.Host;
host.UseDefaultServiceProvider((context, options) =>
{
    var isDevelopment = context.HostingEnvironment.IsDevelopment();
    options.ValidateScopes = isDevelopment;
    options.ValidateOnBuild = isDevelopment;
});

//host.ConfigureKeycloakConfigurationSource("keycloak.json");
//builder.Services.AddKeycloakAuthentication(configuration, o =>
//{
//    o.RequireHttpsMetadata = false;
//});
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Adminstration", builder =>
//    {
//        builder.RequireProtectedResource("workspaces", "workspaces:read") // HTTP request to Keycloak to check protected resource
//            .RequireRealmRoles("Admin") // Realm role is fetched from token
//            .RequireResourceRoles("TEST"); // Resource/Client role is fetched from token
//    });
//})
//    .AddKeycloakAuthorization(configuration);

//.
//builder.Services.AddKeycloakAuthentication(configuration);
//builder.Services.AddAuthorization(o => o.AddPolicy("Adminstration", b =>
//{
//    b.RequireRealmRoles("Admin");
//    b.RequireResourceRoles("TEST"); // stands for "resource admin"
//    // resource roles are mapped to ASP.NET Core Identity roles
//    b.RequireRole("TEST");
//}));
//builder.Services.AddKeycloakAuthorization(configuration);



//builder.Services.AddControllersWithViews();

//builder.Services.AddMvc();
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

//builder.Services.AddAuthentication(options =>
//{
//    // Store the session to cookies
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    // OpenId authentication
//    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//})
//    .AddCookie("Cookies")
//    .AddOpenIdConnect(options =>
//    {
//        // URL of the Keycloak server
//        options.Authority = "http://localhost:8080/auth/";
//        // Client configured in the Keycloak
//        options.ClientId = "TEST";

//        // For testing we disable https (should be true for production)
//        options.RequireHttpsMetadata = false;
//        options.SaveTokens = true;
//        options.ClientId = "TEST";
//        // Client secret shared with Keycloak
//        options.ClientSecret = "6ij5tbkI6gkzyG8botzrjEwwj9rLW6QO";
//        options.GetClaimsFromUserInfoEndpoint = true;

//        // OpenID flow to use
//        options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
//    });


IdentityModelEventSource.ShowPII = true;

//const string clientId = "TEST";
//const string clientSecret = "6ij5tbkI6gkzyG8botzrjEwwj9rLW6QO";  // representative
//const string authority = "http://localhost:8080/auth/";   // name of authority
//builder.Services
//                .AddAuthentication(options =>
//{
//    options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//    options.DefaultAuthenticateScheme = "oidc";
//    options.DefaultSignInScheme = "Cookies";
//})
//                 .AddCookie()
//            .AddOpenIdConnect(options =>
//            {
//                options.CallbackPath = "/home/index";
//                options.Authority = authority;
//                options.ClientId = clientId;
//                options.ClientSecret = clientSecret;
//                options.SaveTokens = true;
//                options.ResponseType = OpenIdConnectResponseType.IdTokenToken;
//                options.RequireHttpsMetadata = false; // dev only
//                options.GetClaimsFromUserInfoEndpoint = true;

//                //options.Scope.Add("openid");  // TODO: not sure how to configure

//                options.Scope.Add("profile");
//                options.Scope.Add("email");

//                options.SaveTokens = true;
//                options.Events = new OpenIdConnectEvents
//                {
//                    OnAuthorizationCodeReceived = context =>
//                    {
//                        // short lived code used to authorise the application on back channel
//                        return Task.CompletedTask;
//                    },
//                    OnRedirectToIdentityProvider = async n =>
//                    {
//                        //save url to state
//                        //  n.ProtocolMessage.State = n.HttpContext.Request.Path.Value.ToString();
//                    },
//                    OnTokenValidated = context =>
//                    {

//                        return Task.CompletedTask;
//                    },
//                    OnTicketReceived = context =>
//                    {
//                        return Task.CompletedTask;
//                    },
//                    OnAuthenticationFailed = context =>
//                    {
//                        context.Response.Redirect("/Home/Error?errormessage = " + context.Exception.Message);
//                        // context.HandleResponse(); // Suppress the exception
//                        return Task.CompletedTask;
//                    },
//                    OnRemoteFailure = context =>
//                    {
//                        context.Response.Redirect("/Home/Error");
//                        context.HandleResponse();
//                        return Task.FromResult(0);
//                    },
//                };

//            });





//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
//            {
//                o.MetadataAddress = "https://localhost:8080/realms/Ecommerce/.well-known/openid-configuration";
//                o.Authority = "https://localhost:8080/realms/Ecommerce/";
//                o.Audience = "account";
//            });





builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Home/Login";
})
.AddOpenIdConnect(options =>
{
    options.Authority = "https://localhost:8080/auth/realms/Ecommerce";
    options.ClientId = "TEST";
    options.ClientSecret = "6ij5tbkI6gkzyG8botzrjEwwj9rLW6QO";
    options.ResponseType = "code";
    options.SaveTokens = true;
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "preferred_username",
        RoleClaimType = "roles"
    };
});



////////

////////////////////////////

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

///keyclock
app.UseAuthentication()
    .UseAuthorization();
//app.MapGet("/workspaces", () => "[]")
//    .RequireAuthorization("RequireWorkspaces");


//app.MapGet("/", (ClaimsPrincipal user) =>
//{
//    app.Logger.LogInformation(user.Identity.Name);
//}).RequireAuthorization("Adminstration");

//app.UseIdentityServer();






///////
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");
app.Services.EnsureMigrationOfContext<ApplicationDbContext>();


app.Run();

