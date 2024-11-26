namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinkler
{
    public sealed record SprinklerResponse(
        Guid PublicId,
        string Name,
        int? SprinklerGroupId,
        double IrrigationCapacityPerMinute);
    
}
