using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.PlanterManagement.CreatePlanter
{
    public sealed record CreatePlanterCommand(
        string Name,
        string Description) : ICommand<PlanterResponse>;
}
