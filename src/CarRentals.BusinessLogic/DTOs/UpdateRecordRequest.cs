namespace CarRentals.BusinessLogic.DTOs;

public class UpdateRecordRequest
{
    public string CarName { get; init; } = null!;

    public DateTime RideFinishedAt { get; init; }
    
    public int PricePerFiveMinutes { get; init; }
    
    public int RideDurationInMinutes { get; init; }
    
    public int Cost { get; init; }
}