using System.Data.Entity.ModelConfiguration;

namespace Labores.Context.Models.Mappings
{
    public class LaborMap : EntityTypeConfiguration<Labores.Entities.Labor>
    {
        public LaborMap()
        {
            ToTable("Labores");

        }
    }
}
