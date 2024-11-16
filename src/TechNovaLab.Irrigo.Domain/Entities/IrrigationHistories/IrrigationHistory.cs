using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.IrrigationHistories
{
    public sealed class IrrigationHistory : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int SprinklerGroupId { get; set; }                
        /// <summary>
        /// Amount of water used during the session (in liters).
        /// </summary>
        public double WaterUsed { get; set; }       
        public int DurationInMinutes { get; set; }
        public DateTime Date { get; set; }
        public SprinklerGroup SprinklerGroup { get; set; } = default!;
    }
}
