namespace TechNovaLab.Irrigo.Application.Features.PlanterManagement.CreatePlanter
{
    public sealed record PlanterResponse(
        Guid PublicId,
        string Name,
        string Description);
}
