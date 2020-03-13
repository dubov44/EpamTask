namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscriptionDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Discription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Discription");
        }
    }
}
