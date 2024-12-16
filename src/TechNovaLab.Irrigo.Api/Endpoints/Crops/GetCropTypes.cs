using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.CropManagement.GetCropTypes;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Crops
{
    internal sealed class GetCropTypes : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("crops", async (ISender sender, CancellationToken cancaellationToken) =>
            {
                var query = new GetCropTypesQuery();

                Result<IEnumerable<CropTypesResponse>> result = await sender.Send(query, cancaellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Guest)
            .HasPermission("users:access")
            .WithTags(Tags.Crops);
        }
    }
}
