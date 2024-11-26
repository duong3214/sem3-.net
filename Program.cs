using Microsoft.EntityFrameworkCore;      // Để sử dụng DbContext và các phương thức EF Core
using ComicSystem.Models;                 // Để sử dụng ComicSystemDbContext và các Model
using Microsoft.Extensions.DependencyInjection; // Để cấu hình dịch vụ
using Microsoft.AspNetCore.Builder;       // Để cấu hình middleware và ứng dụng ASP.NET Core
using Microsoft.AspNetCore.Hosting;       // Để sử dụng các công cụ cho việc triển khai và cấu hình ứng dụng
using Microsoft.Extensions.Hosting;        // Để cấu hình các host (môi trường phát triển hoặc sản xuất)

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext
builder.Services.AddDbContext<ComicSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình Middleware
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
