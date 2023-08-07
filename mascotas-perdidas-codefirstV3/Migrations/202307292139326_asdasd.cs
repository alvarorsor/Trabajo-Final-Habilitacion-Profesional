namespace mascotas_perdidas_codefirstV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "MascotaId", "dbo.Mascotas");
            DropIndex("dbo.Photos", new[] { "MascotaId" });
            AddColumn("dbo.Mascotas", "foto", c => c.Binary(storeType: "image"));
            DropColumn("dbo.Mascotas", "ImageUrl");
            DropTable("dbo.Photos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bytes = c.Binary(),
                        Description = c.String(),
                        FileExtension = c.String(),
                        Size = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MascotaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Mascotas", "ImageUrl", c => c.String());
            DropColumn("dbo.Mascotas", "foto");
            CreateIndex("dbo.Photos", "MascotaId");
            AddForeignKey("dbo.Photos", "MascotaId", "dbo.Mascotas", "ID", cascadeDelete: true);
        }
    }
}
