using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.GetCrops
{
    internal sealed class GetCropsQueryHandler(
        IRepository repository) : IQueryHandler<GetCropsQuery, IEnumerable<CropResponse>>
    {
        public async Task<Result<IEnumerable<CropResponse>>> Handle(GetCropsQuery query, CancellationToken cancellationToken)
        {
            List<CropResponse> crops = await repository
                .Get<Crop>()
                .Include(x => x.CropType)
                .Select(x => new CropResponse
                {
                    Id = x.Id,
                    PublicId = x.PublicId,
                    CropTypeId = x.CropTypeId,
                    DailyWaterConsumption = x.DailyWaterConsumption,
                    Name = x.Name,
                    PlanterId = x.PlanterId,
                    PlantUnits = x.PlantUnits,
                    SprinklerGroupId = x.SprinklerGroupId,
                }).ToListAsync(cancellationToken);

            return crops;
        }
    }
}
