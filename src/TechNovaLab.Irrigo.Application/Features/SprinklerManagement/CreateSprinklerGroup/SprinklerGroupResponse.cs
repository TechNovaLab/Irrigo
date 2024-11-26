using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinklerGroup
{
    public sealed record SprinklerGroupResponse(
        Guid PublicId,
        State State,
        double WaterConsumptionPerSession,
        double ActiveMinutesPerSession);
}
