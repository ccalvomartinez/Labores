using Labores.Entities;
using System.Data.Entity;

namespace Labores.Context.Models
{
    public class LaboresContext : DbContext
    {
        public const string DatabaseConnectionName = @"LaboresContext";
            static LaboresContext()
        {
            Database.SetInitializer<LaboresContext>(null);
        }

            public LaboresContext()
            : base("Name=" + DatabaseConnectionName)
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Labor> Labores { get; set; }
        public DbSet<Material> Materiales { get; set; }
    }
}
