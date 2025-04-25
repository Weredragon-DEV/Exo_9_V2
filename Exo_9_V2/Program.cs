using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Exo_9_V2.Data;

var builder = WebApplication.CreateBuilder(args);

var garageConnectionString = builder.Configuration.GetConnectionString("GarageConnection");
var identityConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<_AppDBContext>(options =>
    options.UseMySql(garageConnectionString, ServerVersion.AutoDetect(garageConnectionString)));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(identityConnectionString, ServerVersion.AutoDetect(identityConnectionString)));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();

// Ajouter Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

// Rediriger "/" vers /Accueil
app.MapGet("/", context =>
{
    context.Response.Redirect("/Accueil");
    return Task.CompletedTask;
});

app.Run();