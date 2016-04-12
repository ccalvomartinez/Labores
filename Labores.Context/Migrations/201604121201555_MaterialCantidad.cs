namespace Labores.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterialCantidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materiales", "Cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materiales", "Cantidad");
        }
    }
}
