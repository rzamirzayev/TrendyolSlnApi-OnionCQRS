using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrendyolSln.Application.Interfaces.Repositories;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Persistence.Context;
using TrendyolSln.Persistence.Repositories;
using TrendyolSln.Persistence.UnitOfWorks;

namespace TrendyolSln.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork,UnitOfWork>();

        }
    }
}
