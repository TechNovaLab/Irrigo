using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Errors
{
    public static  class RestrictionErrors
    {
        public static readonly Error OverlappingDates = Error.Conflict(
            "Restrictions.OverlappingDates", "Irrigation restrictions cannot overlap between specified dates.");
    }
}
