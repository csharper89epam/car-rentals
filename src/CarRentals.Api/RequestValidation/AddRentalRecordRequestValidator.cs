using CarRentals.BusinessLogic.DTOs;
using FluentValidation;

namespace CarRentals.Api.RequestValidation;

public class AddRentalRecordRequestValidator : AbstractValidator<AddRentalRecordRequest>
{
    public AddRentalRecordRequestValidator()
    {
        RuleFor(x => x.CarName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.CreatedBy)
            .MaximumLength(50);
        
        RuleFor(x => x.RideFinishedAt)
            .GreaterThan(default(DateTime));
        
        RuleFor(x => x.PricePerFiveMinutes)
            .GreaterThan(default(int));
        
        RuleFor(x => x.RideDurationInMinutes)
            .GreaterThan(default(int));
        
        RuleFor(x => x.Cost)
            .GreaterThan(default(int));
        
        RuleFor(x => x.Id)
            .NotEqual(default(Guid));
    }
}