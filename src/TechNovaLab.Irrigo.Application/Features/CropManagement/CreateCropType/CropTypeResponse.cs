namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCropType
{
    public sealed record CropTypeResponse(
        Guid PublicId,
        string Name,
        double WaterRequiredPerDay);
}
