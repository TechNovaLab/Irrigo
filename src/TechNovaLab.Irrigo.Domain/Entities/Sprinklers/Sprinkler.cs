using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.Sprinklers
{
    public sealed class Sprinkler : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int? SprinklerGroupId { get; set; }
        public required string Name { get; set; }
        public double IrrigationCapacityPerMinute { get; set; }
        public SprinklerGroup? SprinklerGroup { get; set; } = default!;
    }
}
