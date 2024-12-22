using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCrops
{
    public sealed record GetCropsQuery: IQuery<IEnumerable<CropResponse>>;
}
