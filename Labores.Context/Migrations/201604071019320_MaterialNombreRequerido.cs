namespace Labores.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class MaterialNombreRequerido : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materiales", "Nombre");
            AddColumn("dbo.Materiales", "Nombre", c => c.String(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Materiales", "Nombre");
            AddColumn("dbo.Materiales", "Nombre", c => c.String());
        }
    }
}
