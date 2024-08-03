using CarRentals.Api.RequestValidation;
using CarRentals.BusinessLogic.DTOs;
using CarRentals.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Api.Extensions;

public static class RentalRecordsEndpoints
{
    public static IEndpointRouteBuilder AddRentalRecordsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/stats", async ([FromServices] IRentalRecordsRepository rentalRecordsRepository) =>
        {
            var records = await rentalRecordsRepository.GetAllRecordsAsync();
            return Results.Ok(records);
        });
        
        endpoints.MapGet("/stats/{id:guid}", async ([FromServices] IRentalRecordsRepository rentalRecordsRepository, Guid id) =>
        {
            var record = await rentalRecordsRepository.GetRecordByIdAsync(id);
            return record is not null 
                ? Results.Ok(record) 
                : Results.NotFound();
        });
        
        endpoints.MapDelete("/stats/{id:guid}", async ([FromServices] IRentalRecordsRepository rentalRecordsRepository, Guid id) =>
        {
            var deletedRecord = await rentalRecordsRepository.DeleteRecordAsync(id);
            return deletedRecord is not null 
                ? Results.NoContent()
                : Results.NotFound();
        });

        endpoints.MapPost("/stats", async ([FromBody] List<AddRentalRecordRequest> records, [FromServices] IRentalRecordsService rentalRecordsService) =>
        {
            var recordsWereCreated = await rentalRecordsService.AddRecordsAsync(records);
            return recordsWereCreated
                ? Results.Created()
                : Results.NoContent();
        })
        .AddEndpointFilter<ValidationFilter<List<AddRentalRecordRequest>>>();
        
        endpoints.MapPut("/stats/{id:guid}", async ([FromServices] IRentalRecordsRepository rentalRecordsRepository, Guid id, [FromBody]UpdateRecordRequest request) =>
        {
            var updatedRecord = await rentalRecordsRepository.UpdateRecordAsync(id, request);
            return updatedRecord is not null 
                ? Results.Ok(updatedRecord)
                : Results.NotFound();
        })
        .AddEndpointFilter<ValidationFilter<UpdateRecordRequest>>();

        return endpoints;
    }
}