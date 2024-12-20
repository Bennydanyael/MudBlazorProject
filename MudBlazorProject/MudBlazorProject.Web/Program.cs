using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using MudBlazorProject.Shared.Services;
using MudBlazorProject.Shared.Services.Account;
using MudBlazorProject.Web.Components;
using MudBlazorProject.Web.Services;
using Service.Abstraction.Organization;
using Service.Service.Organization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();
//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IOrgStructureService, OrgStructureService>();

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

// Add device-specific services used by the MudBlazorProject.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

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

app.Run();
