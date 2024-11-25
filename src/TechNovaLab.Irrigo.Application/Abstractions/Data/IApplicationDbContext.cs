using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationHistories;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationRestrictions;
using TechNovaLab.Irrigo.Domain.Entities.IrrigationSchedules;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Entities.Users;

namespace TechNovaLab.Irrigo.Application.Abstractions.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Crop> Crops { get; }
        DbSet<CropType> CropTypes { get; }
        DbSet<IrrigationHistory> IrrigationHistories { get; }
        DbSet<IrrigationRestriction> IrrigationRestrictions { get; }
        DbSet<IrrigationSchedule> IrrigationSchedules { get; }
        DbSet<Planter> Planters { get; }
        DbSet<Sprinkler> Sprinklers { get; }
        DbSet<SprinklerGroup> SprinklerGroups { get; }
        DbSet<User> Users { get; }
    }
}
