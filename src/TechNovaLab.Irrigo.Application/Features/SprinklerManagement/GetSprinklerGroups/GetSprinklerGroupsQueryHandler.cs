using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.GetSprinklerGroups
{
    internal sealed class GetSprinklerGroupsQueryHandler(
        IRepository repository) : IQueryHandler<GetSprinklerGroupsQuery, IEnumerable<SprinklerGroupResponse>>
    {
        public async Task<Result<IEnumerable<SprinklerGroupResponse>>> Handle(GetSprinklerGroupsQuery request, CancellationToken cancellationToken)
        {
            List<SprinklerGroupResponse> sprinklerGroups = await repository
                .Get<SprinklerGroup>()
                .Select(x => new SprinklerGroupResponse
                {
                    Id = x.Id,
                    PublicId = x.PublicId,
                    Name = x.Name,
                    State = x.State,
                    WaterConsumptionPerSession = x.WaterConsumptionPerSession,
                    ActiveMinutesPerSession = x.ActiveMinutesPerSession,
                }).ToListAsync(cancellationToken);

            return sprinklerGroups;
        }
    }
}
