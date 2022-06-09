namespace AlbumMusique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Albums", newName: "Album");
            CreateTable(
                "dbo.Artiste",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Piste",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duree = c.Int(nullable: false),
                        Nom = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.AlbumArtiste",
                c => new
                    {
                        Album_Id = c.Int(nullable: false),
                        Artiste_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Album_Id, t.Artiste_Id })
                .ForeignKey("dbo.Album", t => t.Album_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artiste", t => t.Artiste_Id, cascadeDelete: true)
                .Index(t => t.Album_Id)
                .Index(t => t.Artiste_Id);
            
            DropColumn("dbo.Album", "NombreDePistes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Album", "NombreDePistes", c => c.Int(nullable: false));
            DropForeignKey("dbo.Piste", "Album_Id", "dbo.Album");
            DropForeignKey("dbo.AlbumArtiste", "Artiste_Id", "dbo.Artiste");
            DropForeignKey("dbo.AlbumArtiste", "Album_Id", "dbo.Album");
            DropIndex("dbo.AlbumArtiste", new[] { "Artiste_Id" });
            DropIndex("dbo.AlbumArtiste", new[] { "Album_Id" });
            DropIndex("dbo.Piste", new[] { "Album_Id" });
            DropTable("dbo.AlbumArtiste");
            DropTable("dbo.Piste");
            DropTable("dbo.Artiste");
            RenameTable(name: "dbo.Album", newName: "Albums");
        }
    }
}
