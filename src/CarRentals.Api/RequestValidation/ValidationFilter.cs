using CarRentals.Api.Exceptions;
using FluentValidation;

namespace CarRentals.Api.RequestValidation;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = GetValidator(context);
        var objectToValidate = GetObjectToValidate(context);
        var validationResult = await validator.ValidateAsync(objectToValidate);
        return validationResult.IsValid
            ? await next(context)
            : Results.ValidationProblem(validationResult.ToDictionary());
    }

    private IValidator<T> GetValidator(EndpointFilterInvocationContext context)
    {
        return context.HttpContext.RequestServices.GetService<IValidator<T>>()
            ?? throw new FailedToValidateRequestException($"Could not find a validator for type {typeof(T)}");
    }

    private T GetObjectToValidate(EndpointFilterInvocationContext context)
    {
        var objectToValidate = context.Arguments
            .OfType<T>()
            .FirstOrDefault(x => x?.GetType() == typeof(T));
        
        return objectToValidate
            ?? throw new FailedToValidateRequestException($"Could not find a request parameter of type {typeof(T)}");
    }
}