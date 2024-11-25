using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.SharedKernel.Core
{
    public abstract class DomainException(ErrorType errorType, string message) : Exception(message)
    {
        public ErrorType ErrorType { get; } = errorType;
    }

    
}
