using Labores.Context.Models.Mappings;
using Labores.Entities;
using System.Data.Entity;

namespace Labores.Context.Models
{
    public class LaboresContext : DbContext
    {
        public const string DatabaseConnectionName = @"LaboresContext";


        public LaboresContext()
            : base("name=" + DatabaseConnectionName)
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Labor> Labores { get; set; }
        public DbSet<Material> Materiales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LaborMap());
            modelBuilder.Configurations.Add(new MaterialMap());
        }
    }
}
