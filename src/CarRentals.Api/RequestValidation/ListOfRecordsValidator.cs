using CarRentals.BusinessLogic.DTOs;
using FluentValidation;

namespace CarRentals.Api.RequestValidation;

public class ListOfRecordsValidator : AbstractValidator<List<AddRentalRecordRequest>>
{
    public ListOfRecordsValidator()
    {
        RuleFor(x => x).NotEmpty();
        RuleForEach(x => x).SetValidator(new AddRentalRecordRequestValidator());
    }
}