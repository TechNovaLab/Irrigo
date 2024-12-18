using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCropTypes
{
    public sealed record GetCropTypesQuery: IQuery<IEnumerable<CropTypeResponse>>;

}
