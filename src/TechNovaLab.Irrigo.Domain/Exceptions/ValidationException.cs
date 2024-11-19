using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Exceptions
{
    public sealed class ValidationException(string? message)
        : DomainException(
            ErrorType.Validation,
            message ?? "One or more validation errors occurred. Please check the provided input and try again.");
}
