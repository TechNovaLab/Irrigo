using TechNovaLab.Irrigo.SharedKernel.Providers;

namespace TechNovaLab.Irrigo.Infrastructure.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
