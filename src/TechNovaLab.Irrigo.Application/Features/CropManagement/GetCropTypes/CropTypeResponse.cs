namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCropTypes
{
    public sealed record CropTypeResponse
    {
        public Guid PublicId { get; init; }
        public string Name { get; init; } = default!;
        public double WaterRequiredPerDay { get; init; }
    }
}
