using CarRentals.Api.RequestValidation;
using FluentValidation;

namespace CarRentals.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwaggerForDevelopment(this IServiceCollection services, IWebHostEnvironment environment)
    {
        if (!environment.IsDevelopment())
            return services;
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
    
    public static IServiceCollection AddAppInsightsForProduction(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
            return services;
        
        var appInsightsConnectionString = configuration
            .GetSection("ApplicationInsights")
            .GetValue<string>("ConnectionString");
        
        services.AddApplicationInsightsTelemetry(options =>
        {
            options.ConnectionString = appInsightsConnectionString;
        });
        
        return services;
    }
    
    public static IServiceCollection AddRequestValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<AddRentalRecordRequestValidator>();
        
        return services;
    }
}