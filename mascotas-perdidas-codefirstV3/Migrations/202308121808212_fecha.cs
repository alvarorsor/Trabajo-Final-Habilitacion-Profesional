namespace mascotas_perdidas_codefirstV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mascotas", "fecha_extravio", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mascotas", "fecha_extravio", c => c.DateTime(storeType: "date"));
        }
    }
}
