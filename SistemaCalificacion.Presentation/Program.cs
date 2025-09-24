using Microsoft.EntityFrameworkCore;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Application.Services;
using SistemaCalificacion.Domain.Interfaces;
using SistemaCalificacion.Infrastructure.Data;
using SistemaCalificacion.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(option=> 
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the UserRepository with dependency injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
