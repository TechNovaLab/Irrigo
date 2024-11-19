using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Exceptions
{
    public sealed class ProblemException(string? message)
        : DomainException(
            ErrorType.Problem,
            message ?? "An unexpected problem occurred while processing your request. Please try again later.");

}
