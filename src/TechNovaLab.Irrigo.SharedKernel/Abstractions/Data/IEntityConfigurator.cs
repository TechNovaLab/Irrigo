namespace TechNovaLab.Irrigo.SharedKernel.Abstractions.Data
{
    public interface IEntityConfigurator
    {
        bool ApplySeed { get; set; }
        void Seed(IModelBuilder modelBuilder);
        void Configure(IModelBuilder modelBuilder);
    }
}
