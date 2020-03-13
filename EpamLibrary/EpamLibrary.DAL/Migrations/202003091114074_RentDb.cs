namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "ClientProfile_ClientProfileId", "dbo.ClientProfiles");
            DropIndex("dbo.Books", new[] { "ClientProfile_ClientProfileId" });
            AddColumn("dbo.RentedBooks", "Name", c => c.String());
            DropColumn("dbo.Books", "ClientProfileId");
            DropColumn("dbo.Books", "ClientProfile_ClientProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ClientProfile_ClientProfileId", c => c.String(maxLength: 128));
            AddColumn("dbo.Books", "ClientProfileId", c => c.Int());
            DropColumn("dbo.RentedBooks", "Name");
            CreateIndex("dbo.Books", "ClientProfile_ClientProfileId");
            AddForeignKey("dbo.Books", "ClientProfile_ClientProfileId", "dbo.ClientProfiles", "ClientProfileId");
        }
    }
}
