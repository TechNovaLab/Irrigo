using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.UserManagement.Login;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Users
{
    internal sealed class Login : IEndpoint
    {
        public sealed record Request(string Email, string Password);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("users/Login", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new LoginUserCommand(request.Email, request.Password);

                Result<string> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .AllowAnonymous()
            .WithTags(Tags.Users);
        }
    }
}
