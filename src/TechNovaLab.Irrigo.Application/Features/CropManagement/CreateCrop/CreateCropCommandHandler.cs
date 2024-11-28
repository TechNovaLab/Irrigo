using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Application.Services.Crops.Interfaces;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCrop
{
    internal sealed class CreateCropCommandHandler(
        IRepository repository,
        IUnitOfWork unitOfWork,
        ICropValidationService validationService) : ICommandHandler<CreateCropCommand, CropResponse>
    {
        public async Task<Result<CropResponse>> Handle(CreateCropCommand command, CancellationToken cancellationToken)
        {
            var validations = new[]
            {
                await validationService.ValidateNameIsUniqueAsync(command.Name, cancellationToken),
                await validationService.ValidateSprinklerGroupIsAvailableAsync(command.SprinklerGroupId, cancellationToken),
                await validationService.ValidateCropTypeInPlanterAsync(command.CropTypeId, command.PlanterId, cancellationToken),
                await validationService.ValidatePlanterCapacityAsync(command.PlanterId, cancellationToken)
            };

            foreach (var validation in validations)
            {
                if(validation.IsFailure)
                {
                    return Result.Failure<CropResponse>(validation.Error);
                }
            }
            
            var crop = new Crop
            {
                PublicId = Guid.NewGuid(),
                Name = command.Name,
                PlantUnits = command.PlantUnits,
                CropTypeId = command.CropTypeId,
                PlanterId = command.PlanterId,
                SprinklerGroupId = command.SprinklerGroupId,
            };

            await repository.AddAsync(crop, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new CropResponse(
                crop.PublicId,
                crop.Name,
                crop.PlantUnits,
                crop.CropTypeId,
                crop.PlanterId,
                crop.SprinklerGroupId);
        }
    }
}
