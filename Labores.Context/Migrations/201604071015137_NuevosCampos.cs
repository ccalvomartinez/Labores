namespace Labores.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class NuevosCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Labores", "Título", c => c.String());
            AddColumn("dbo.Materiales", "Nombre", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Labores", "Título");
            DropColumn("dbo.Materiales", "Nombre");
        }
    }
}
