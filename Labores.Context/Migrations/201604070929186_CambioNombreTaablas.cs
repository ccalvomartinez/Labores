namespace Labores.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioNombreTaablas : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Labors", newName: "Labores");
            RenameTable(name: "dbo.Materials", newName: "Materiales");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Materiales", newName: "Materials");
            RenameTable(name: "dbo.Labores", newName: "Labors");
        }
    }
}
