namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCropType
{
    public sealed record CropTypeResponse(
        int Id,
        Guid PublicId,
        string Name,
        double WaterRequiredPerDay);
}
