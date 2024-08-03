using CarRentals.BusinessLogic.Interfaces;
using CarRentals.BusinessLogic.Services;
using CarRentals.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentals.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("RentalRecords");
        services.AddDbContext<RentalRecordsContext>(options => options.UseSqlite(connection));
        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IRentalRecordsRepository, RentalRecordsRepository>();
        
        return services;
    }
    
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddTransient<IRentalRecordsService, RentalRecordsService>();
        
        return services;
    }
}