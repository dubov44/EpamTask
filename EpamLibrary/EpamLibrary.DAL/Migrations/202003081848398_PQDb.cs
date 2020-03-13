namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PQDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Quantity");
        }
    }
}
