using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Exceptions
{
    public sealed class InvalidArgumentException(string paramName, object? paramValue)
        : DomainException(
            ErrorType.Failure,
            $"The argument '{paramName}' has an invalid value: '{paramValue}'. Please provide a valid value and try again.");

}
