using Microsoft.Extensions.DependencyInjection;
using Vleko.DAL.Interface;
using Vleko.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Midtrans.Payment.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(
                configuration.GetConnectionString("MainConnection"), (option) =>
                {
                    option.CommandTimeout(3600);
                    option.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                }));
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            return services;
        }
    }
}
