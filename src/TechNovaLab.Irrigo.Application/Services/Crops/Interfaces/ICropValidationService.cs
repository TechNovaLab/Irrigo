using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Services.Crops.Interfaces
{
    internal interface ICropValidationService
    {
        Task<Result> ValidateNameIsUniqueAsync(string name, CancellationToken cancellationToken = default);
        Task<Result> ValidateSprinklerGroupIsAvailableAsync(int sprinklerGroupId, CancellationToken cancellationToken = default);
        Task<Result> ValidateCropTypeInPlanterAsync(int cropTypeId, int planterId, CancellationToken cancellationToken = default);
        Task<Result> ValidatePlanterCapacityAsync(int planterId, CancellationToken cancellationToken = default);        
    }
}