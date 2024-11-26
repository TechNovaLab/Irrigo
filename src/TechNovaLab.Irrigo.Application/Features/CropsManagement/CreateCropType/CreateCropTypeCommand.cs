using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.CropsManagement.CreateCropType
{
    public sealed record CreateCropTypeCommand(
        string Name,
        int WaterRequiredPerDay) : ICommand<CropTypeResponse>;
}
