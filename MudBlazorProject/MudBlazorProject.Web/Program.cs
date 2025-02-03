using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using MudBlazorProject.Shared.Services;
using MudBlazorProject.Shared.Services.Account;
using MudBlazorProject.Web.Components;
using MudBlazorProject.Web.Services;
using Providers.Abstraction.Context;
using Providers.DataProvider.Context;
using Serilog;
using Service.Abstraction.Organization;
using Service.Infrastructure;
using Service.Service.Organization;
using Service.Service.TokenHandler;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBaseDbContext(builder.Configuration);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddConfigureServices();
//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

builder.Services.AddSingleton<HttpClient>();
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddScoped<IOrgStructureService, OrgStructureService>();

//builder.Services.AddAuthorizationCore();
//builder.Services.AddCascadingAuthenticationState();
//builder.Services.AddBlazoredSessionStorage(config => {
//    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
//    config.JsonSerializerOptions.IgnoreNullValues = true;
//    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
//    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
//    config.JsonSerializerOptions.WriteIndented = false;
//});
//builder.Services.AddBlazoredSessionStorageAsSingleton();
//builder.Services.AddSessionStorageServices();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(c =>
{
    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(c =>
{
    c.RequireHttpsMetadata = false;
    c.SaveToken = true;
    c.TokenValidationParameters = new TokenValidationParameters
    {
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTTokenHandler.JWT_SECURITY_KEY))
    };
});
builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins", policy =>
{
    policy.WithOrigins("https://localhost:44396").AllowAnyMethod().AllowAnyHeader();
}));
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration)
);

// Add device-specific services used by the MudBlazorProject.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitializer.InitializeSets();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseAuthentication();
//app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(MudBlazorProject.Shared._Imports).Assembly);
app.UseSerilogRequestLogging(p => p.Logger = new LoggerConfiguration()
.WriteTo.File("logs/log_"+DateTime.Now.ToString("yyyyMMdd")+".txt", rollingInterval: RollingInterval.Day).CreateLogger());
app.Run();
