namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCrops
{
    public sealed record CropResponse
    {
        public int Id { get; init; }
        public  Guid PublicId { get; init; }
        public int CropTypeId { get; init; }
        public int PlanterId { get; init; }
        public int SprinklerGroupId { get; init; }
        public string Name { get; init; } = default!;
        public int PlantUnits { get; init; }
        public double DailyWaterConsumption { get; init; }
    }
}
