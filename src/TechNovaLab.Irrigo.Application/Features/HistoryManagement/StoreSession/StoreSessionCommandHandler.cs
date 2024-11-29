using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Histories;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;
using TechNovaLab.Irrigo.SharedKernel.Providers;

namespace TechNovaLab.Irrigo.Application.Features.HistoryManagement.StoreSession
{
    internal sealed class StoreSessionCommandHandler(
        IRepository repository, 
        IUnitOfWork unitOfWork, 
        IDateTimeProvider dateTimeProvider) : ICommandHandler<StoreSessionCommand, HistoryResponse>
    {
        public async Task<Result<HistoryResponse>> Handle(StoreSessionCommand command, CancellationToken cancellationToken)
        {
            var history = new History
            {
                PublicId = Guid.NewGuid(),
                SprinklerGroupId = command.SprinklerGroupId,
                WaterUsed = command.WaterUsed,
                DurationInMinutes = command.DurationInMinutes,
                Date = dateTimeProvider.UtcNow,
            };

            await repository.AddAsync(history, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new HistoryResponse(
                history.PublicId,
                history.SprinklerGroupId,
                history.WaterUsed,
                history.DurationInMinutes,
                history.Date);
        }
    }
}
