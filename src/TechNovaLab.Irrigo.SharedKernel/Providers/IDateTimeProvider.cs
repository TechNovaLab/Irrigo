namespace TechNovaLab.Irrigo.SharedKernel.Providers
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
