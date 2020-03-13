namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublisherDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Editions", newName: "Publishers");
            RenameColumn(table: "dbo.Books", name: "EditionId", newName: "PublisherId");
            RenameIndex(table: "dbo.Books", name: "IX_EditionId", newName: "IX_PublisherId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_PublisherId", newName: "IX_EditionId");
            RenameColumn(table: "dbo.Books", name: "PublisherId", newName: "EditionId");
            RenameTable(name: "dbo.Publishers", newName: "Editions");
        }
    }
}
