using CarRentals.BusinessLogic.DTOs;
using CarRentals.BusinessLogic.Interfaces;
using CarRentals.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CarRentals.Infrastructure.Repositories;

public class RentalRecordsRepository(RentalRecordsContext ctx, TimeProvider timeProvider) : IRentalRecordsRepository
{
    public async Task<List<RentalRecordResponse>> GetAllRecordsAsync()
    {
        return await ctx.RentalRecords
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.RideFinishedAt)
            .Select(x => new RentalRecordResponse(
                x.Id, 
                x.CarName, 
                x.RideFinishedAt, 
                x.RideDurationInMinutes, 
                x.PricePerFiveMinutes, 
                x.Cost
            )).ToListAsync();
    }

    public async Task AddRecordsAsync(List<AddRentalRecordRequest> records)
    {
        var currentTime = timeProvider.GetUtcNow().DateTime;
        var dbModels = records
            .Select(x => x.ToDbModel(currentTime));

        await ctx.RentalRecords.AddRangeAsync(dbModels);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Guid>> GetAlreadyExistingIdsAsync(List<Guid> ids)
    {
        return await ctx.RentalRecords
            .Where(x => ids.Contains(x.Id))
            .Select(x => x.Id)
            .ToListAsync();
    }

    public async Task<RentalRecordResponse?> GetRecordByIdAsync(Guid id)
    {
        var dbModel = await ctx.RentalRecords.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        return dbModel?.ToApiResponse();
    }

    public async Task<RentalRecordResponse?> DeleteRecordAsync(Guid id)
    {
        var dbModel = await ctx.RentalRecords.FirstOrDefaultAsync(x => x.Id == id);
        if (dbModel is null)
            return null;

        dbModel.IsDeleted = true;
        await ctx.SaveChangesAsync();
        return dbModel.ToApiResponse();
    }
    
    public async Task<RentalRecordResponse?> UpdateRecordAsync(Guid id, UpdateRecordRequest request)
    {
        var dbModel = await ctx.RentalRecords.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (dbModel is null)
            return null;

        dbModel.CarName = request.CarName;
        dbModel.RideFinishedAt = request.RideFinishedAt;
        dbModel.PricePerFiveMinutes = request.PricePerFiveMinutes;
        dbModel.RideDurationInMinutes = request.RideDurationInMinutes;
        dbModel.Cost = request.Cost;
        
        await ctx.SaveChangesAsync();
        return dbModel.ToApiResponse();
    }
}