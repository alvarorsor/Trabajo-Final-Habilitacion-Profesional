namespace mascotas_perdidas_codefirstV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqired2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mascota_Usuario", "nombreUsuario", c => c.String(nullable: false));
            DropColumn("dbo.Mascota_Usuario", "IDUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mascota_Usuario", "IDUsuario", c => c.Int(nullable: false));
            DropColumn("dbo.Mascota_Usuario", "nombreUsuario");
        }
    }
}
