using CarRentals.BusinessLogic.DTOs;

namespace CarRentals.Infrastructure.Extensions;

public static class RentalRecordsMapper
{
    public static RentalRecordResponse ToApiResponse(this DbModels.RentalRecord dbModel)
    {
        return new RentalRecordResponse(
            dbModel.Id, 
            dbModel.CarName, 
            dbModel.RideFinishedAt, 
            dbModel.RideDurationInMinutes, 
            dbModel.PricePerFiveMinutes, 
            dbModel.Cost);
    }
    
    public static DbModels.RentalRecord ToDbModel(this AddRentalRecordRequest request, DateTime currentTime)
    {
        return new DbModels.RentalRecord
        {
            Id = request.Id,
            Cost = request.Cost,
            RideFinishedAt = request.RideFinishedAt,
            CarName = request.CarName,
            RideDurationInMinutes = request.RideDurationInMinutes,
            PricePerFiveMinutes = request.PricePerFiveMinutes,
            IsDeleted = false,
            CreatedBy = request.CreatedBy ?? "N/A",
            CreatedAt = currentTime
        };
    }
}