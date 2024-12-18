using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.PlanterManagement.GetPlanters
{
    public sealed record GetPlantersQuery: IQuery<IEnumerable<PlanterResponse>>;
}
