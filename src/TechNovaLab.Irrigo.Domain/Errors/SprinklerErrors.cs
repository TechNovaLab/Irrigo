using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Errors
{
    public static class SprinklerErrors
    {
        public static readonly Error NameNotUnique = Error.Conflict(
            "Sprinklers.NameNotUnique", "The provided name is not unique.");
    }
}
