using System.ComponentModel.DataAnnotations.Schema;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;

namespace TechNovaLab.Irrigo.Domain.Entities.Crops
{
    public sealed class Crop
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int CropTypeId { get; set; }
        public int PlanterId { get; set; }
        public int SprinklerGroupId { get; set; }
        public required string Name { get; set; }
        /// <summary>
        /// Number of individual plants or units of this crop type planted in the planter.
        /// </summary>
        public int PlantUnits { get; set; }

        [NotMapped]
        /// <summary>
        /// Total daily water consumption for this crop in the planter, calculated as:
        /// Water required per unit of crop type * Number of plant units.
        /// </summary>
        public double DailyWaterConsumption
        {
            get
            {
                if (CropType != null)
                {
                    return (double)CropType.WaterRequiredPerDay * PlantUnits;
                }

                return 0D;
            }
        }

        public CropType CropType { get; set; } = default!;
        public Planter Planter { get; set; } = default!;
        public SprinklerGroup SprinklerGroup { get; set; } = default!;
    }
}
