namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebtDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientProfiles", "Debt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientProfiles", "Debt");
        }
    }
}
