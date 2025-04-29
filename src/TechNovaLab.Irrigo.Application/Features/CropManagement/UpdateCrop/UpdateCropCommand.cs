using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.UpdateCrop
{
    public sealed record UpdateCropCommand(
        Guid PublicId,
        string Name,
        int PlantUnits,
        int CropTypeId,
        int PlanterId,
        int SprinklerGroupId) : ICommand<CropResponse>;
}
