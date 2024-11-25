﻿using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Crops;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationHistories;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationRestrictions;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurations.IrrigationSchedules;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Planters;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurations.Sprinklers;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Configurators
{
    internal static class EntityModelConfigurator
    {
        public static void ApplyModelConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyCropsModelConfiguration();
            modelBuilder.ApplyIrrigationHistoryModelConfiguration();
            modelBuilder.ApplyIrrigationRestrictionsModelConfiguration();
            modelBuilder.ApplyIrrigationScheduleModelConfiguration();
            modelBuilder.ApplyPlantersModelConfiguration();
            modelBuilder.ApplySprinklersModelConfiguration();
        }
    }
}
