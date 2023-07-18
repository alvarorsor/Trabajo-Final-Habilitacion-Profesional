namespace mascotas_perdidas_codefirstV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foto3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mascotas", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mascotas", "ImageUrl");
        }
    }
}
