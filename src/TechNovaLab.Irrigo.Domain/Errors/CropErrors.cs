using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Errors
{
    public static class CropErrors
    {
        public static readonly Error NameNotUnique = Error.Conflict(
            "Crops.NameNotUnique", "The provided name is not unique.");

        public static readonly Error SprinklerGroupInUse = Error.Conflict(
            "Crops.SprinklerGroupInUse", "The sprinkler group is already assigned to another crop.");

        public static readonly Error CropTypeAlreadyInPlanter = Error.Conflict(
            "Crops.CropTypeAlreadyInPlanter", "Another crop of the same type exists in the planter.");

        public static readonly Error PlanterMaxCropsExceeded = Error.Conflict(
            "Crops.PlanterMaxCropsExceeded", "The planter cannot have more than two crops.");

        public static readonly Error PlantUnitsOutOfRange = Error.Conflict(
            "Crops.PlantUnitsOutOfRange", "The number of plant units must be between 1 and 8.");

        public static readonly Error CropTypeInvalid = Error.Conflict(
            "Crops.CropTypeInvalid", "The crop type must be greater than 0.");

        public static readonly Error PlanterInvalid = Error.Conflict(
            "Crops.PlanterInvalid", "The planter must be greater than 0.");

        public static readonly Error SprinklerGroupInvalid = Error.Conflict(
            "Crops.SprinklerGroupInvalid", "The sprinkler group must be greater than 0.");

        public static Error NotFound(string paramName, object? paramValue) => Error.NotFound(
            "Crops.NotFound", $"The '{paramName}' with the Id = '{paramValue}' was not found.");
    }
}
