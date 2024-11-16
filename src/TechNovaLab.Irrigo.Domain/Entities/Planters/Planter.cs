using TechNovaLab.Irrigo.Domain.Entities.Crops;

namespace TechNovaLab.Irrigo.Domain.Entities.Planters
{
    public sealed class Planter
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; } = default!;        
        public string Description { get; set; } = default!;
        public ICollection<Crop> Crops { get; set; } = [];
    }
}
