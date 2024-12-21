using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.GetSprinklerGroups
{
    public sealed record GetSprinklerGroupsQuery : IQuery<IEnumerable<SprinklerGroupResponse>>;
}
