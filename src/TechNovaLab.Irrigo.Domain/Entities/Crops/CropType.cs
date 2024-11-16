namespace TechNovaLab.Irrigo.Domain.Entities.Crops
{
    public sealed class CropType
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public required string Name { get; set; }
        /// <summary>
        /// Amount of water required per day (in liters).
        /// </summary>
        public int WaterRequiredPerDay { get; set; }
        public ICollection<Crop> Crops { get; set; } = [];
    }
}
