using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Application.Services.Crops.Interfaces;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.UpdateCrop
{
    internal sealed class UpdateCropCommandHandler(
        IRepository repository,
        IUnitOfWork unitOfWork,
        ICropValidationService validationService) : ICommandHandler<UpdateCropCommand, CropResponse>
    {
        public async Task<Result<CropResponse>> Handle(UpdateCropCommand command, CancellationToken cancellationToken)
        {
            Crop? crop = await repository
                .Get<Crop>(x => x.PublicId == command.PublicId)
                .FirstOrDefaultAsync(cancellationToken);

            if (crop is null)
            {
                return Result.Failure<CropResponse>(CropErrors.NotFound(nameof(Crop), command.PublicId));
            }

            var nameIsUnique = await validationService.ValidateNameIsUniqueAsync(command.Name, cancellationToken);
            if (nameIsUnique.IsFailure)
                return Result.Failure<CropResponse>(nameIsUnique.Error);

            if (crop.SprinklerGroupId != command.SprinklerGroupId)
            {
                var sprinklerGroupIsAvailable = await validationService.ValidateSprinklerGroupIsAvailableAsync(command.SprinklerGroupId, cancellationToken);
                if (sprinklerGroupIsAvailable.IsFailure)
                    return Result.Failure<CropResponse>(sprinklerGroupIsAvailable.Error);
            }

            if (crop.CropTypeId != command.CropTypeId || crop.PlanterId != command.PlanterId)
            {
                var cropTypeInPlanter = await validationService.ValidateCropTypeInPlanterAsync(command.CropTypeId, command.PlanterId, cancellationToken);
                if(cropTypeInPlanter.IsFailure) 
                    return Result.Failure<CropResponse>(cropTypeInPlanter.Error);
            }

            var planterCapacity = await validationService.ValidatePlanterCapacityAsync(command.PlanterId, cancellationToken);
            if(planterCapacity.IsFailure)
                return Result.Failure<CropResponse>(planterCapacity.Error);

            crop.Name = command.Name;
            crop.PlantUnits = command.PlantUnits;
            crop.CropTypeId = command.CropTypeId;
            crop.PlanterId = command.PlanterId;
            crop.SprinklerGroupId = command.SprinklerGroupId;

            repository.Update(crop);

            await unitOfWork.CompleteAsync(cancellationToken);

            return new CropResponse(
                crop.Id,
                crop.PublicId,
                crop.Name,
                crop.PlantUnits,
                crop.CropTypeId,
                crop.PlanterId,
                crop.SprinklerGroupId);
        }
    }
}
