using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.HistoryManagement.StoreSession
{
    public sealed record StoreSessionCommand(
        int SprinklerGroupId,
        double WaterUsed,
        int DurationInMinutes) : ICommand<HistoryResponse>;
}
