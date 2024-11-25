using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;
using TechNovaLab.Irrigo.Infrastructure.Database.Contexts;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Repositories
{
    public class Repository(ApplicationDbContext context) : RepositoryBase(context), IRepository;
}
