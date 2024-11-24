using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.UserManagement.Register;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Users
{
    internal sealed class Register : IEndpoint
    {
        public sealed record Request(string Email, string FirstName, string LastName, string Password);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("users/register", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new RegisterUserCommand(
                    request.Email,
                    request.FirstName,
                    request.LastName,
                    request.Password);

                Result<Guid> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .AllowAnonymous()
            .WithTags(Tags.Users);
        }
    }
}
