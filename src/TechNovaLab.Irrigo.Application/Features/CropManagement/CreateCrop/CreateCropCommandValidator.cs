using FluentValidation;
using TechNovaLab.Irrigo.Domain.Errors;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCrop
{
    internal sealed class CreateCropCommandValidator : AbstractValidator<CreateCropCommand>
    {
        public CreateCropCommandValidator()
        {
            RuleFor(x => x.PlantUnits)
                .InclusiveBetween(1, 8)
                .WithMessage(CropErrors.PlantUnitsOutOfRange.Description);

            RuleFor(x => x.CropTypeId)
                .GreaterThan(0)
                .WithMessage(CropErrors.CropTypeInvalid.Description);

            RuleFor(x => x.PlanterId)
                .GreaterThan(0)
                .WithMessage(CropErrors.PlanterInvalid.Description);

            RuleFor(x => x.SprinklerGroupId)
                .GreaterThan(0)
                .WithMessage(CropErrors.SprinklerGroupInvalid.Description);
        }
    }
}
