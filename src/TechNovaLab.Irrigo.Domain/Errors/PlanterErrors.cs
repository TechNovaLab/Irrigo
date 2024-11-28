using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Errors
{
    public static class PlanterErrors
    {
        public static readonly Error NameNotUnique = Error.Conflict(
            "Planters.NameNotUnique", "The provided name is not unique.");
    }
}
