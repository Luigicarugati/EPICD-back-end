using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleApp.Data;
using PoliziaMunicipaleApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi i servizi al container.
builder.Services.AddControllersWithViews();

// Configura il database context
builder.Services.AddDbContext<PoliziaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura la pipeline HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
