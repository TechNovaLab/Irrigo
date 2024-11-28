using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Services.Crops.Interfaces;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Services.Crops
{
    internal class CropValidationService(IRepository repository) : ICropValidationService
    {
        public async Task<Result> ValidateCropTypeInPlanterAsync(int cropTypeId, int planterId, CancellationToken cancellationToken = default)
        {
            var cropType = await repository.FindAsync<CropType>(cropTypeId, cancellationToken);

            if (cropType is null)
            {
                return Result.Failure(CropErrors.NotFound(nameof(CropType), cropTypeId));
            }

            var palnterId = await repository.FindAsync<Planter>(planterId, cancellationToken);

            if(palnterId is null)
            {
                return Result.Failure(CropErrors.NotFound(nameof(Planter), planterId));
            }

            var isCropTypeAlreadyInPlanter = await repository.Get<Crop>()
                .AnyAsync(x => x.CropTypeId == cropTypeId && x.PlanterId == planterId, cancellationToken);

            return isCropTypeAlreadyInPlanter
                ? Result.Failure(CropErrors.CropTypeAlreadyInPlanter)
                : Result.Success();
        }

        public async Task<Result> ValidateNameIsUniqueAsync(string name, CancellationToken cancellationToken = default)
        {
            var isNameNotUnique = await repository.Get<Crop>()
                .AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);

            return isNameNotUnique
                ? Result.Failure(CropErrors.NameNotUnique)
                : Result.Success();
        }

        public async Task<Result> ValidatePlanterCapacityAsync(int planterId, CancellationToken cancellationToken = default)
        {
            var palnterId = await repository.FindAsync<Planter>(planterId, cancellationToken);

            if (palnterId is null)
            {
                return Result.Failure(CropErrors.NotFound(nameof(Planter), planterId));
            }

            var isPlanterMaxCropsExceeded = await repository.Get<Crop>()
                .CountAsync(x => x.PlanterId == planterId, cancellationToken) >= 2;

            return isPlanterMaxCropsExceeded
                ? Result.Failure(CropErrors.PlanterMaxCropsExceeded)
                : Result.Success();
        }

        public async Task<Result> ValidateSprinklerGroupIsAvailableAsync(int sprinklerGroupId, CancellationToken cancellationToken = default)
        {
            var sprinklerGroup = await repository.FindAsync<Planter>(sprinklerGroupId, cancellationToken);

            if (sprinklerGroup is null)
            {
                return Result.Failure(CropErrors.NotFound(nameof(SprinklerGroup), sprinklerGroupId));
            }

            var isSprinklerGroupInUse = await repository.Get<Crop>()
                .AnyAsync(x => x.SprinklerGroupId == sprinklerGroupId, cancellationToken);

            return isSprinklerGroupInUse
                ? Result.Failure(CropErrors.SprinklerGroupInUse)
                : Result.Success();
        }
    }
}
