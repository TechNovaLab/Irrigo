using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinklerGroup
{
    public sealed record CreateSprinklerGroupCommand : ICommand<SprinklerGroupResponse>;
}
