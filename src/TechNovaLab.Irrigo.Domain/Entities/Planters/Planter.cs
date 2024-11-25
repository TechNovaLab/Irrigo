using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.Planters
{
    public sealed class Planter : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; } = default!;        
        public string Description { get; set; } = default!;
        public ICollection<Crop> Crops { get; set; } = [];
    }
}
