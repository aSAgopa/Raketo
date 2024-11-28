using Microsoft.EntityFrameworkCore;
using Raketo.Managers;
using Raketo.Interfaces;
using Raketo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DBConnectionOne");
builder.Services.AddDbContext<MarketDB>(options => options.UseSqlServer(connection));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MarketDB>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<Repository>();
builder.Services.AddScoped<IProducts,Fish>();
builder.Services.AddScoped<IProducts,Beverages>();
builder.Services.AddScoped<IProducts,Meat>();
builder.Services.AddScoped<IProducts,Vegetables>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();

Console.WriteLine("555");
