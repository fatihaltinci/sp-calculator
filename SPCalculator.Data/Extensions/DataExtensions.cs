using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPCalculator.Data.Context;
using SPCalculator.Data.Repositories.Abstraction;
using SPCalculator.Data.Repositories.Concretes;
using SPCalculator.Data.UnitOfWorks;

namespace SPCalculator.Data.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection LoadDataExtensions(this IServiceCollection services, IConfiguration config) // 
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // IRepository interface'ini Repository class'ına bağladık. Her IRepository istendiğinde Repository class'ı çağırılacak.
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection"))); // Veritabanı bağlantısı için DefaultConnection adını verdiğimiz için GetConnectionString ile onu aldık.
            
            services.AddScoped<IUnitOfWork, UnitOfWork>(); // IUnitOfWork interface'ini UnitOfWork class'ına bağladık. Her IUnitOfWork istendiğinde UnitOfWork class'ı çağırılacak.
            return services;
        }
    }
}
