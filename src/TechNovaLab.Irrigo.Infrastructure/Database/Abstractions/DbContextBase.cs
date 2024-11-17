using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.SharedKernel.Abstractions.Data;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Abstractions
{
    public abstract class DbContextBase(DbContextOptions options) : DbContext(options), IDatabaseContext;
}
