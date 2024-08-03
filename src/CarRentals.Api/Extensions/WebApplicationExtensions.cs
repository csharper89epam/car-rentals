namespace CarRentals.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void UseSwaggerForDevelopment(this WebApplication app, IWebHostEnvironment environment)
    {
        if (!environment.IsDevelopment())
            return;

        app.UseSwagger();
        app.UseSwaggerUI();
    }
}