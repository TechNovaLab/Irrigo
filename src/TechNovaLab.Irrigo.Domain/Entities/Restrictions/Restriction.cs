﻿using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Domain.Entities.Restrictions
{
    public sealed class Restriction : EntityBase
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        public Season Season { get; set; }
        public RestrictionSeverity Severity { get; set; }
        /// <summary>
        /// Maximum allowed water quantity during the restriction period (in liters).
        /// </summary>
        public double MaxWaterLimit { get; set; }        
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
        public string? Reason { get; set; }
    }
}
