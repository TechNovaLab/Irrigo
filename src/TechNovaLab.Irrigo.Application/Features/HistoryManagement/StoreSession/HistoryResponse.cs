namespace TechNovaLab.Irrigo.Application.Features.HistoryManagement.StoreSession
{
    public sealed record HistoryResponse(
        Guid PublicId,
        int SprinklerGroupId,
        double WaterUsed,
        int DurationInMinutes,
        DateTime Date);
}
