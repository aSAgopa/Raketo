using Microsoft.EntityFrameworkCore;
using Raketo.Managers;
using Raketo.Interfaces;
using Raketo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DBConnectionOne");
builder.Services.AddDbContext<MarketDB>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();


