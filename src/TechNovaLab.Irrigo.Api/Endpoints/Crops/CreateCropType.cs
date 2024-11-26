using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.CropsManagement.CreateCropType;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Crops
{
    internal sealed class CreateCropType : IEndpoint
    {
        public sealed record Request(string Name, int WaterRequiredPerDay);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("crops/create-crop-type", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateCropTypeCommand(
                    request.Name, 
                    request.WaterRequiredPerDay);

                Result<CropTypeResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            });
        }
    }
}
