namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RBDb2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Requests", new[] { "ClientProfile_ClientProfileId" });
            DropColumn("dbo.Requests", "ClientProfileId");
            RenameColumn(table: "dbo.Requests", name: "ClientProfile_ClientProfileId", newName: "ClientProfileId");
            AlterColumn("dbo.Requests", "ClientProfileId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Requests", "ClientProfileId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Requests", new[] { "ClientProfileId" });
            AlterColumn("dbo.Requests", "ClientProfileId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Requests", name: "ClientProfileId", newName: "ClientProfile_ClientProfileId");
            AddColumn("dbo.Requests", "ClientProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "ClientProfile_ClientProfileId");
        }
    }
}
