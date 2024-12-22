using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinklerGroup
{
    internal sealed class CreateSprinklerGroupCommandHandler(
        IRepository repository,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateSprinklerGroupCommand, SprinklerGroupResponse>
    {
        public async Task<Result<SprinklerGroupResponse>> Handle(CreateSprinklerGroupCommand command, CancellationToken cancellationToken)
        {            
            var group = new SprinklerGroup
            {
                PublicId = Guid.NewGuid(),
                Name = command.Name,
                State = State.Inactive,
            };

            await repository.AddAsync(group, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new SprinklerGroupResponse(
                group.Id,
                group.PublicId,
                group.Name,
                group.State,
                group.WaterConsumptionPerSession,
                group.ActiveMinutesPerSession);
        }
    }
}
