using Microsoft.EntityFrameworkCore;
using PruebaProducto.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//configuracion de la cadena de la base de datos
builder.Services.AddDbContext<GestionProductoContext>(Opcion =>
        Opcion.UseSqlServer(builder.Configuration.GetConnectionString("sql"))
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
