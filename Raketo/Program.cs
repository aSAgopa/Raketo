using Microsoft.EntityFrameworkCore;
using Raketo.Infrastructure;
using Raketo.Interfaces;
using Raketo.Services;
using Raketo.ViewModel;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DBConnectionOne") ??
    throw new ArgumentException(nameof(connection));
builder.Services.AddScoped<IUiService<ProductViewModel>, ProductService>();
builder.Services.AddInfrastructure(connection);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();


