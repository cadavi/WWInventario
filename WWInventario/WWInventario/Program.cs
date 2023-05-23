using Microsoft.EntityFrameworkCore;
using WWInventario.Data;
using WWInventario.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:WWInventarioDbConn"]);
});

builder.Services.AddScoped<IEquipoService, EquipoService>();
builder.Services.AddScoped<IDispositivosService, DispositivosService>();
builder.Services.AddScoped<ICompaniasService, CompaniasService>();
builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed database
AppDbInitializer.Seed(app);

app.Run();
