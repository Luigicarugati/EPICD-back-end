using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzeriaInFornoWebApp.Data;
using PizzeriaInFornoWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

//  DbContext con la stringa di connessione
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity con ruoli
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//  servizi MVC
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Aggiungi Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Esegui  seeding  ruoli e  utenti
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    await EnsureRolesAsync(roleManager);
    await EnsureAdminUserAsync(userManager);
    await EnsureStandardUserAsync(userManager);
}

async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
{
    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

async Task EnsureAdminUserAsync(UserManager<IdentityUser> userManager)
{
    var adminEmail = "admin@pizzeriainforno.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail
        };
        var result = await userManager.CreateAsync(adminUser, "Admin123!");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

async Task EnsureStandardUserAsync(UserManager<IdentityUser> userManager)
{
    var userEmail = "user@pizzeriainforno.com";
    var standardUser = await userManager.FindByEmailAsync(userEmail);

    if (standardUser == null)
    {
        standardUser = new IdentityUser
        {
            UserName = userEmail,
            Email = userEmail
        };
        var result = await userManager.CreateAsync(standardUser, "User123!");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(standardUser, "User");
        }
    }
}

// Configura la pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Abilita l'uso di file statici (come CSS, JS)
app.UseRouting(); // Configura il routing
app.UseAuthentication(); // Abilita l'autenticazione
app.UseAuthorization();
app.UseSession(); // Abilita la sessione

// Configura le route di default
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// Esegui l'app
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
