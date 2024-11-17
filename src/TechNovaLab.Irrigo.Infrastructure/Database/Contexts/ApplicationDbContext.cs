using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContextBase(options)
    {
    }
}
