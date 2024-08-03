using CarRentals.BusinessLogic.DTOs;
using CarRentals.BusinessLogic.Interfaces;

namespace CarRentals.BusinessLogic.Services;

public class RentalRecordsService(IRentalRecordsRepository repository) : IRentalRecordsService
{
    public async Task<bool> AddRecordsAsync(List<AddRentalRecordRequest> records)
    {
        var newRecords = await FilterOutExistingRecordsAsync(records);

        if (newRecords.Count == 0)
            return false;
            
        await repository.AddRecordsAsync(newRecords);
        return true;
    }

    private async Task<List<AddRentalRecordRequest>> FilterOutExistingRecordsAsync(List<AddRentalRecordRequest> records)
    {
        var ids = records
            .Select(x => x.Id)
            .ToList();

        var existingIds = await repository.GetAlreadyExistingIdsAsync(ids);

        return records
            .Where(x => !existingIds.Contains(x.Id))
            .ToList();
    }
}