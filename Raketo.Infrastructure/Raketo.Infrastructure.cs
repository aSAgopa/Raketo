using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Raketo.BL.Interfaces;
using Raketo.BL.Services;
using Raketo.DAL;
using Raketo.DAL.Entities;
using Raketo.DAL.Entities.Interfaces;
using Raketo.Model;

namespace Raketo.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<MarketDBContext>(options =>
                options.UseSqlServer(connectionString));
                     
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IService<ProductDto>, ProductService>();
            services.AddScoped<IUserService<UserDto>, UserService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
