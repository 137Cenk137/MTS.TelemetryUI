using ApexCharts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Radzen;
using TelemetryUI.Client.Pages;
using TelemetryUI.Components;
using TelemetryUI.Entityframework.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();
builder.Services.AddApexCharts();

builder.Services.AddRadzenComponents();
builder.Services.AddCascadingAuthenticationState();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

builder.Services.AddSingleton(provider => 
{
   // var dbContext = provider.GetRequiredService<TelemetryDbContext>();
    var logger = provider.GetRequiredService<ILogger<TelemetryService>>();
    var scopeFactory = provider.GetRequiredService<IServiceScopeFactory>();

    return new TelemetryService(
        logger,
        scopeFactory,
        portName: "/dev/cu.usbserial-130",
        baundName: 9600
    );
});
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();


builder.Services.AddDbContext<TelemetryDbContext>(opt => opt.UseSqlite("Data Source=./TelemetryDbContext.db"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TelemetryUI.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.


app.Run();
