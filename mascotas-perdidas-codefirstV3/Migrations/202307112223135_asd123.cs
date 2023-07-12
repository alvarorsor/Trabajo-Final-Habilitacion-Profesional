namespace mascotas_perdidas_codefirstV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Especies", "Mascota_ID", "dbo.Mascotas");
            DropIndex("dbo.Especies", new[] { "Mascota_ID" });
            AddColumn("dbo.Mascotas", "IDEspecie", c => c.Int(nullable: false));
            CreateIndex("dbo.Mascotas", "IDEspecie");
            AddForeignKey("dbo.Mascotas", "IDEspecie", "dbo.Especies", "ID", cascadeDelete: true);
            DropColumn("dbo.Especies", "Mascota_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Especies", "Mascota_ID", c => c.Int());
            DropForeignKey("dbo.Mascotas", "IDEspecie", "dbo.Especies");
            DropIndex("dbo.Mascotas", new[] { "IDEspecie" });
            DropColumn("dbo.Mascotas", "IDEspecie");
            CreateIndex("dbo.Especies", "Mascota_ID");
            AddForeignKey("dbo.Especies", "Mascota_ID", "dbo.Mascotas", "ID");
        }
    }
}
