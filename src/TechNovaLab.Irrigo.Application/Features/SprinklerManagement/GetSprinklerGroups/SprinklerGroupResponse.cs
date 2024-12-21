using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.GetSprinklerGroups
{
    public sealed record SprinklerGroupResponse
    {
        public Guid PublicId { get; init; }
        public string Name { get; init; } = default!;
        public State State { get; init; }
        public double WaterConsumptionPerSession { get; init; }
        public double ActiveMinutesPerSession { get; init; }
    }
}
