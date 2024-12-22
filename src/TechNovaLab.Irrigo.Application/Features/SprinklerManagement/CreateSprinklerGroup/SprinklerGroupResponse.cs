using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinklerGroup
{
    public sealed record SprinklerGroupResponse(
        int Id,
        Guid PublicId,
        string Name,
        State State,
        double WaterConsumptionPerSession,
        double ActiveMinutesPerSession);
}
