using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinkler
{
    internal sealed class CreateSprinklerCommandHandler(
        IRepository repository, 
        IUnitOfWork unitOfWork) : ICommandHandler<CreateSprinklerCommand, SprinklerResponse>
    {
        public async Task<Result<SprinklerResponse>> Handle(CreateSprinklerCommand request, CancellationToken cancellationToken)
        {
            var anySprinkler = await repository
                .Get<Sprinkler>()
                .AnyAsync(x => x.Name == request.Name, cancellationToken);

            if(anySprinkler)
            {
                return Result.Failure<SprinklerResponse>(SprinklerErrors.NameNotUnique);
            }

            var sprinkler = new Sprinkler
            {
                PublicId = Guid.NewGuid(),
                Name = request.Name,
                IrrigationCapacityPerMinute = request.IrrigationCapacityPerMinute,
            };

            await repository.AddAsync(sprinkler, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new SprinklerResponse(
                sprinkler.PublicId, 
                sprinkler.Name, 
                sprinkler.SprinklerGroupId, 
                sprinkler.IrrigationCapacityPerMinute);            
        }
    }
    
}
