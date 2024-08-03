namespace CarRentals.Infrastructure.DbModels;

public class RentalRecord
{
    public required string CarName { get; set; }
    
    public required DateTime RideFinishedAt { get; set; }
    
    public required int PricePerFiveMinutes { get; set; }
    
    public required int RideDurationInMinutes { get; set; }
    
    public required int Cost { get; set; }
    
    public required bool IsDeleted { get; set; }
    
    public required Guid Id { get; set; }
    
    public required DateTime CreatedAt { get; set; }
    
    public required string CreatedBy { get; set; }
}