using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCrop;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Crops
{
    internal sealed class CreateCrop : IEndpoint
    {
        public sealed record Request(
            string Name,
            int PlantUnits,
            int CropTypeId,
            int PlanterId,
            int SprinklerGroupId);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("crops/create-crop", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateCropCommand(
                    request.Name,
                    request.PlantUnits,
                    request.CropTypeId,
                    request.PlanterId,
                    request.SprinklerGroupId);

                Result<CropResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            });
        }
    }
}
