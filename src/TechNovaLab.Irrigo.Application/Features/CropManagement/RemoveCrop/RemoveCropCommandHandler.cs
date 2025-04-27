using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.RemoveCrop
{
    public sealed class RemoveCropCommandHandler(
        IRepository repository,
        IUnitOfWork unitOfWork) : ICommandHandler<RemoveCropCommand, RemoveCropResponse>
    {
        public async Task<Result<RemoveCropResponse>> Handle(RemoveCropCommand request, CancellationToken cancellationToken)
        {
            var crop = await repository
                .Get<Crop>(x => x.PublicId == request.PublicId)
                .SingleOrDefaultAsync(cancellationToken);

            if (crop != null)
            {
                repository.Remove(crop);
                await unitOfWork.CompleteAsync(cancellationToken);

                return new RemoveCropResponse(true);
            }

            return Result.Failure<RemoveCropResponse>(CropErrors.NotFound(nameof(Crop), request.PublicId));
        }
    }
}
