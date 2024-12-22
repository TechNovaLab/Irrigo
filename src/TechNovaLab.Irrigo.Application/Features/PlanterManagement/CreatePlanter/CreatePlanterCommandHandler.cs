using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.PlanterManagement.CreatePlanter
{
    internal sealed class CreatePlanterCommandHandler(
        IRepository repository, 
        IUnitOfWork unitOfWork) : ICommandHandler<CreatePlanterCommand, PlanterResponse>
    {
        public async Task<Result<PlanterResponse>> Handle(CreatePlanterCommand command, CancellationToken cancellationToken)
        {
            var anyPlanter = await repository
                .Get<Planter>()
                .AnyAsync(x => x.Name == command.Name, cancellationToken);

            if(anyPlanter)
            {
                return Result.Failure<PlanterResponse>(PlanterErrors.NameNotUnique);
            }

            var planter = new Planter
            {
                PublicId = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
            };

            await repository.AddAsync(planter, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new PlanterResponse(
                planter.Id,
                planter.PublicId,
                planter.Name,
                planter.Description);
        }
    }
}
