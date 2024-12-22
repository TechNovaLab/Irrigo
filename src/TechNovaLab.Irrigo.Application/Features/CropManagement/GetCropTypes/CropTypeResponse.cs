namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCropTypes
{
    public sealed record CropTypeResponse
    {
        public int Id { get; init; }
        public Guid PublicId { get; init; }
        public string Name { get; init; } = default!;
        public double WaterRequiredPerDay { get; init; }
    }
}
