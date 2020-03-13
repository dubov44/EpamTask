namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditionDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Editions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "PublicationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "EditionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "EditionId");
            AddForeignKey("dbo.Books", "EditionId", "dbo.Editions", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "IsAvaliable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "IsAvaliable", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Books", "EditionId", "dbo.Editions");
            DropIndex("dbo.Books", new[] { "EditionId" });
            DropColumn("dbo.Books", "EditionId");
            DropColumn("dbo.Books", "PublicationDate");
            DropTable("dbo.Editions");
        }
    }
}
