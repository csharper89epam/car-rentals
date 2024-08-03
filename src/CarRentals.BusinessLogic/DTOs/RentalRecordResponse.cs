namespace CarRentals.BusinessLogic.DTOs;

public record RentalRecordResponse(
    Guid Id,
    string CarName,
    DateTime RideFinishedAt,
    int RideDurationInMinutes,
    int PricePerFiveMinutes,
    int Cost);