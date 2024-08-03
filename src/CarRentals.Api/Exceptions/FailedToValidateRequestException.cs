namespace CarRentals.Api.Exceptions;

public class FailedToValidateRequestException(string message) : Exception(message);