namespace TechNovaLab.Irrigo.Application.Features.CropsManagement.CreateCropType
{
    public sealed record CropTypeResponse(
        Guid PublicId,
        string Name,
        int WaterRequiredPerDay);
}
