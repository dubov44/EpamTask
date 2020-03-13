namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientProfileId = c.Int(nullable: false),
                        RentedBookId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ClientProfile_ClientProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfile_ClientProfileId)
                .ForeignKey("dbo.RentedBooks", t => t.RentedBookId, cascadeDelete: true)
                .Index(t => t.RentedBookId)
                .Index(t => t.ClientProfile_ClientProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "RentedBookId", "dbo.RentedBooks");
            DropForeignKey("dbo.Requests", "ClientProfile_ClientProfileId", "dbo.ClientProfiles");
            DropIndex("dbo.Requests", new[] { "ClientProfile_ClientProfileId" });
            DropIndex("dbo.Requests", new[] { "RentedBookId" });
            DropTable("dbo.Requests");
        }
    }
}
