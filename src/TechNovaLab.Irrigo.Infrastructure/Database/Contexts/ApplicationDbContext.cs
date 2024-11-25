using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationHistories;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationRestrictions;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationSchedules;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurators;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContextBase(options), IApplicationDbContext
    {
        public DbSet<Crop> Crops { get; set; } = default!;
        public DbSet<CropType> CropTypes { get; set; } = default!;
        public DbSet<IrrigationHistory> IrrigationHistories { get; set; } = default!;
        public DbSet<IrrigationRestriction> IrrigationRestrictions { get; set; } = default!;
        public DbSet<IrrigationSchedule> IrrigationSchedules { get; set; } = default!;
        public DbSet<Planter> Planters { get; set; } = default!;
        public DbSet<Sprinkler> Sprinklers { get; set; } = default!;
        public DbSet<SprinklerGroup> SprinklerGroups { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyModelConfiguration();
            modelBuilder.HasDefaultSchema(Schemas.Default);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
