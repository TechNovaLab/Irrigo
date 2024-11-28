using TechNovaLab.Irrigo.SharedKernel.Errors;

namespace TechNovaLab.Irrigo.Domain.Errors
{
    public static class ScheduleErrors
    {
        public static Error NotFound(string paramName, object? paramValue) => Error.NotFound(
            "Schedules.NotFound", $"The '{paramName}' with the Id = '{paramValue}' was not found.");

        public static readonly Error SprinklerGroupConflict = Error.Conflict(
            "Schedules.Conflict", "There cannot be another schedule for the same sprinkler group while another one is active.");

    }
}
