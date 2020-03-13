namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RBDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "RentedBookId", "dbo.RentedBooks");
            DropIndex("dbo.Requests", new[] { "RentedBookId" });
            AddColumn("dbo.Requests", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "BookId");
            AddForeignKey("dbo.Requests", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            DropColumn("dbo.Requests", "RentedBookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "RentedBookId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Requests", "BookId", "dbo.Books");
            DropIndex("dbo.Requests", new[] { "BookId" });
            DropColumn("dbo.Requests", "BookId");
            CreateIndex("dbo.Requests", "RentedBookId");
            AddForeignKey("dbo.Requests", "RentedBookId", "dbo.RentedBooks", "Id", cascadeDelete: true);
        }
    }
}
