using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.IrrigationRestrictions
{
    public sealed class IrrigationRestriction : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        public Season Season { get; set; }
        public Severity Severity { get; set; }
        /// <summary>
        /// Maximum allowed water quantity during the restriction period (in liters).
        /// </summary>
        public double MaxWaterLimit { get; set; }
        /// <summary>
        /// Maximum number of times irrigation is allowed per week.
        /// </summary>
        public int MaxIrrigationFrequencyPerWeek { get; set; }
        /// <summary>
        /// Start date and time when the restriction begins.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date and time when the restriction ends.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Specifies the allowed time range for irrigation during the restriction period.
        /// </summary>
        public TimeSpan AllowedStartTime { get; set; }
        public TimeSpan AllowedEndTime { get; set; }
        public string RestrictionReason { get; set; } = default!;
    }
}
