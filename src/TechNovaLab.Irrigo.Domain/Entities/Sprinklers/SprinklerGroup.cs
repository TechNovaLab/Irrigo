using System.ComponentModel.DataAnnotations.Schema;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationHistories;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationSchedules;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.Sprinklers
{
    public sealed class SprinklerGroup : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public State State { get; set; }

        [NotMapped]
        public double WaterConsumptionPerSession
        {
            get
            {
                if (Crops.Any(c => c.SprinklerGroupId == Id) && 
                    IrrigationSchedules.Any(x => x.SprinklerGroupId == Id))
                {
                    var irrigationSession = IrrigationSchedules.Count;
                    var waterConsumption = Crops
                        .First(c => c.SprinklerGroupId == Id)
                        .DailyWaterConsumption;

                    return waterConsumption / irrigationSession;
                }

                return 0D;
            }
        }

        [NotMapped]
        public double ActiveMinutesPerSession
        {
            get
            {
                if (Sprinklers.Count != 0)
                {
                    var capacity = Sprinklers.Sum(x => x.IrrigationCapacityPerMinute);
                    return WaterConsumptionPerSession / capacity;
                }

                return 0D;
            }
        }

        public ICollection<Crop> Crops { get; set; } = [];
        public ICollection<Sprinkler> Sprinklers { get; set; } = [];
        public ICollection<IrrigationSchedule> IrrigationSchedules { get; set; } = [];
        public ICollection<IrrigationHistory> IrrigationHistories { get; set; } = [];
    }
}
