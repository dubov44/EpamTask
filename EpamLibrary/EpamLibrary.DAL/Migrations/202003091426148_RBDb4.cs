namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RBDb4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "ClientName", c => c.String());
            AddColumn("dbo.Requests", "BookName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "BookName");
            DropColumn("dbo.Requests", "ClientName");
        }
    }
}
