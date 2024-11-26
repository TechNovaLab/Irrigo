using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Errors
{
    public static class CropTypeErrors
    {
        public static readonly Error NameNotUnique = Error.Conflict(
            "CropTypes.NameNotUnique", "The provided name is not unique.");
    }
}
