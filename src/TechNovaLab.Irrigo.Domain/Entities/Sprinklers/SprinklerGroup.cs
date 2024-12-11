using System.ComponentModel.DataAnnotations.Schema;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Entities.Histories;
using TechNovaLab.Irrigo.Domain.Entities.Schedules;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.Sprinklers
{
    public sealed class SprinklerGroup : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        public State State { get; set; }

        [NotMapped]
        public double WaterConsumptionPerSession
        {
            get
            {
                if (Crops.Any(c => c.SprinklerGroupId == Id) && 
                    Schedules.Any(x => x.SprinklerGroupId == Id))
                {
                    var irrigationSession = Schedules.Count;
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
        public ICollection<Schedule> Schedules { get; set; } = [];
        public ICollection<History> Histories { get; set; } = [];
    }
}
