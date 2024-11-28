using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCrop
{
    public sealed record CreateCropCommand(
        string Name,
        int PlantUnits,
        int CropTypeId,
        int PlanterId,
        int SprinklerGroupId) : ICommand<CropResponse>;
}
