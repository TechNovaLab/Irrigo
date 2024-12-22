using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCropTypes
{
    internal sealed class GetCropTypesQueryHandler(
        IRepository repository) : IQueryHandler<GetCropTypesQuery, IEnumerable<CropTypeResponse>>
    {
        public async Task<Result<IEnumerable<CropTypeResponse>>> Handle(GetCropTypesQuery query, CancellationToken cancellationToken)
        {
            List<CropTypeResponse> cropTypes = await repository
                .Get<CropType>()
                .Select(x => new CropTypeResponse
                {
                    Id = x.Id,
                    PublicId = x.PublicId,
                    Name = x.Name,
                    WaterRequiredPerDay = x.WaterRequiredPerDay,
                }).ToListAsync(cancellationToken);

            return cropTypes;
        }
    }

}
