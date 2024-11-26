using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinkler
{
    public sealed record CreateSprinklerCommand(
        string Name, 
        int? SprinklerGroupId,
        double IrrigationCapacityPerMinute) : ICommand<SprinklerResponse>;
    
}
