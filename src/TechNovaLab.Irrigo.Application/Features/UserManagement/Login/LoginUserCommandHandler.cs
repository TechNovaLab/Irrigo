using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Authentication;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Login
{
    internal sealed class LoginUserCommandHandler(
        IRepository repository, 
        IPasswordHasher passwordHasher, 
        ITokenProvider tokenProvider) : ICommandHandler<LoginUserCommand, string>
    {
        public async Task<Result<string>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            User? user = await repository
                .Get<User>(x => x.Email == command.Email)
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                return Result.Failure<string>(UserErrors.NotFoundByEmail);
            }

            bool verified = passwordHasher.Verify(command.Password, user.PasswordHash);

            if (!verified)
            {
                return Result.Failure<string>(UserErrors.NotFoundByEmail);
            }

            string token = tokenProvider.Create(user);

            return token;
        }
    }
}
