namespace TechNovaLab.Irrigo.Application.Features.PlanterManagement.CreatePlanter
{
    public sealed record PlanterResponse(
        int Id,
        Guid PublicId,
        string Name,
        string Description);
}
