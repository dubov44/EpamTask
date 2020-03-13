namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RBDb5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RentedBooks", new[] { "ClientProfile_ClientProfileId" });
            DropColumn("dbo.RentedBooks", "ClientProfileId");
            RenameColumn(table: "dbo.RentedBooks", name: "ClientProfile_ClientProfileId", newName: "ClientProfileId");
            AlterColumn("dbo.RentedBooks", "ClientProfileId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RentedBooks", "ClientProfileId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RentedBooks", new[] { "ClientProfileId" });
            AlterColumn("dbo.RentedBooks", "ClientProfileId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RentedBooks", name: "ClientProfileId", newName: "ClientProfile_ClientProfileId");
            AddColumn("dbo.RentedBooks", "ClientProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.RentedBooks", "ClientProfile_ClientProfileId");
        }
    }
}
