using TechNovaLab.Irrigo.Domain.Entities.Users;

namespace TechNovaLab.Irrigo.Application.Abstractions.Authentication
{
    public interface ITokenProvider
    {
        string Create(User user);
    }
}
