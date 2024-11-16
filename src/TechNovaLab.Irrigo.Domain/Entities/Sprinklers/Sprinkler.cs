namespace TechNovaLab.Irrigo.Domain.Entities.Sprinklers
{
    public sealed class Sprinkler
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int? SprinklerGroupId { get; set; }
        public required string Name { get; set; }
        public double IrrigationCapacity { get; set; }
        public SprinklerGroup? SprinklerGroup { get; set; } = default!;
    }
}
