using CarRentals.Api.Extensions;
using CarRentals.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerForDevelopment(builder.Environment);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddAppInsightsForProduction(builder.Configuration, builder.Environment);
builder.Services.AddBusinessLogic();
builder.Services.AddRequestValidators();
builder.Configuration
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json");

var app = builder.Build();
app.UseSwaggerForDevelopment(builder.Environment);
app.UseHttpsRedirection();
app.AddRentalRecordsEndpoints();

app.Run();
