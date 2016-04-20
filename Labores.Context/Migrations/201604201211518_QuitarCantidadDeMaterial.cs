namespace Labores.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitarCantidadDeMaterial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materiales", "Cantidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materiales", "Cantidad", c => c.Int(nullable: false));
        }
    }
}
