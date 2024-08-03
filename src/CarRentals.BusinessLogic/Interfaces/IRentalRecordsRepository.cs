using CarRentals.BusinessLogic.DTOs;

namespace CarRentals.BusinessLogic.Interfaces;

public interface IRentalRecordsRepository
{
    Task<List<RentalRecordResponse>> GetAllRecordsAsync();

    Task AddRecordsAsync(List<AddRentalRecordRequest> records);

    Task<List<Guid>> GetAlreadyExistingIdsAsync(List<Guid> ids);

    Task<RentalRecordResponse?> GetRecordByIdAsync(Guid id);
    
    Task<RentalRecordResponse?> DeleteRecordAsync(Guid id);

    Task<RentalRecordResponse?> UpdateRecordAsync(Guid id, UpdateRecordRequest request);
}