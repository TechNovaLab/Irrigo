using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.PlanterManagement.GetPlanters
{
    internal sealed class GetPlantersQueryHandler(
        IRepository repository) : IQueryHandler<GetPlantersQuery, IEnumerable<PlanterResponse>>
    {
        public async Task<Result<IEnumerable<PlanterResponse>>> Handle(GetPlantersQuery query, CancellationToken cancellationToken)
        {
            List<PlanterResponse> planters = await repository
                .Get<Planter>()
                .Select(x => new PlanterResponse
                {
                    Id = x.Id,
                    PublicId = x.PublicId,
                    Name = x.Name,
                    Description = x.Description,
                }).ToListAsync(cancellationToken);

            return planters;
        }
    }
}
