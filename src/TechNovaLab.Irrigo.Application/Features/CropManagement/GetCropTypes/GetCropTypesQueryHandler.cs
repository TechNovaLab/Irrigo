using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCropTypes
{
    internal sealed class GetCropTypesQueryHandler(
        IRepository repository) : IQueryHandler<GetCropTypesQuery, IEnumerable<CropTypesResponse>>
    {
        public async Task<Result<IEnumerable<CropTypesResponse>>> Handle(GetCropTypesQuery request, CancellationToken cancellationToken)
        {
            List<CropTypesResponse> cropTypes = await repository
                .Get<CropType>()
                .Select(x => new CropTypesResponse
                {
                    PublicId = x.PublicId,
                    Name = x.Name,
                    WaterRequiredPerDay = x.WaterRequiredPerDay,
                }).ToListAsync(cancellationToken);

            return cropTypes;
        }
    }

}
