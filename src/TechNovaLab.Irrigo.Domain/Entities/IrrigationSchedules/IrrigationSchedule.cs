using System.ComponentModel.DataAnnotations.Schema;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.IrrigationSchedules
{
    public sealed class IrrigationSchedule : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int SprinklerGroupId { get; set; }        
        public TimeSpan StartTime { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Notes { get; set; }
        
        [NotMapped]
        public TimeSpan EndTime
        {
            get
            {
                if (SprinklerGroup?.ActiveMinutesPerSession > 0)
                {
                    return StartTime.Add(TimeSpan.FromMinutes(Convert.ToDouble(SprinklerGroup.ActiveMinutesPerSession)));
                }

                return StartTime;
            }
        }

        public SprinklerGroup SprinklerGroup { get; set; } = default!;
    }
}
