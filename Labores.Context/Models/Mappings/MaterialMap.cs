using System.Data.Entity.ModelConfiguration;

namespace Labores.Context.Models.Mappings
{
    public class MaterialMap : EntityTypeConfiguration<Labores.Entities.Material>
    {
        public MaterialMap()
        {
            ToTable("Materiales");
        }
    }
}
