using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Exceptions
{
    public sealed class OperationFailedException(string? message)
        : DomainException(
            ErrorType.Failure,
            message ?? "The requested operation could not be completed. Please try again later if the problem persists.");

}
