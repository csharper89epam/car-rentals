using CarRentals.BusinessLogic.DTOs;

namespace CarRentals.BusinessLogic.Interfaces;

public interface IRentalRecordsService
{
    Task<bool> AddRecordsAsync(List<AddRentalRecordRequest> records);
}