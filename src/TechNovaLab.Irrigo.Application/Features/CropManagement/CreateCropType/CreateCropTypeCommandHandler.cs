using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCropType
{
    internal sealed class CreateCropTypeCommandHandler(
        IRepository repository,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateCropTypeCommand, CropTypeResponse>
    {
        public async Task<Result<CropTypeResponse>> Handle(CreateCropTypeCommand command, CancellationToken cancellationToken)
        {
            var anyCropType = await repository
                .Get<CropType>()
                .AnyAsync(x => x.Name == command.Name, cancellationToken);

            if (anyCropType)
            {
                return Result.Failure<CropTypeResponse>(CropTypeErrors.NameNotUnique);
            }

            var cropType = new CropType
            {
                PublicId = Guid.NewGuid(),
                Name = command.Name,
                WaterRequiredPerDay = command.WaterRequiredPerDay,
            };

            await repository.AddAsync(cropType, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new CropTypeResponse(
                cropType.PublicId,
                cropType.Name,
                cropType.WaterRequiredPerDay);
        }
    }
}
