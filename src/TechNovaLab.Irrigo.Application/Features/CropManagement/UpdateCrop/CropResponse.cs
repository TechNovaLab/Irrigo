namespace TechNovaLab.Irrigo.Application.Features.CropManagement.UpdateCrop
{
    public sealed record CropResponse(
        int Id,
        Guid PublicId,
        string Name,
        int PlantUnits,
        int CropTypeId,
        int PlanterId,
        int SprinklerGroupId);
}
