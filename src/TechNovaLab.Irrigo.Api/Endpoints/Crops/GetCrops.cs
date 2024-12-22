using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.CropManagement.GetCrops;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Crops
{
    internal sealed class GetCrops : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("crops", async (ISender sender, CancellationToken cancellationToken) =>
            {
                var query = new GetCropsQuery();

                Result<IEnumerable<CropResponse>> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Guest)
            .HasPermission("users:access")
            .WithTags(Tags.Crops);
        }
    }
}
