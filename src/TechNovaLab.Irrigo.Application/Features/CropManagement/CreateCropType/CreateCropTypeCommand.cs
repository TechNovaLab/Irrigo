using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCropType
{
    public sealed record CreateCropTypeCommand(
        string Name,
        int WaterRequiredPerDay) : ICommand<CropTypeResponse>;
}
