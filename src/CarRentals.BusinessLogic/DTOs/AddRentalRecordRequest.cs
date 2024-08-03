namespace CarRentals.BusinessLogic.DTOs;

public class AddRentalRecordRequest
{
    public string CarName { get; init; } = null!;

    public DateTime RideFinishedAt { get; init; }
    
    public int PricePerFiveMinutes { get; init; }
    
    public int RideDurationInMinutes { get; init; }
    
    public int Cost { get; init; }
    
    public Guid Id { get; init; }
    
    public string? CreatedBy { get; init; }
}