using Microsoft.EntityFrameworkCore;

namespace TechNovaLab.Irrigo.Application.Abstractions.Data
{
    public interface IEntityConfigurator
    {
        bool ApplySeed { get; set; }
        void Seed(ModelBuilder modelBuilder);
        void Configure(ModelBuilder modelBuilder);
    }
}
