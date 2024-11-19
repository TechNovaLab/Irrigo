using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Exceptions
{
    public sealed class ConflictException(string? message)
        : DomainException(
            ErrorType.Conflict,
            message ?? "A conflict occurred with the current state of the resource. Please resolve the conflict and try again.");

}
