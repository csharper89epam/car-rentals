using CarRentals.BusinessLogic.DTOs;
using FluentValidation;

namespace CarRentals.Api.RequestValidation;

public class UpdateRecordRequestValidator : AbstractValidator<UpdateRecordRequest>
{
    public UpdateRecordRequestValidator()
    {
        RuleFor(x => x.CarName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.RideFinishedAt)
            .GreaterThan(default(DateTime));
        
        RuleFor(x => x.PricePerFiveMinutes)
            .GreaterThan(default(int));
        
        RuleFor(x => x.RideDurationInMinutes)
            .GreaterThan(default(int));
        
        RuleFor(x => x.Cost)
            .GreaterThan(default(int));
    }
}