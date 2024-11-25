using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Exceptions
{
    public sealed class NotFoundException(string paramName, object? paramValue)
        : DomainException(
            ErrorType.NotFound,
            $"The resource identified by '{paramName}' with value '{paramValue}' was not found.");

}
