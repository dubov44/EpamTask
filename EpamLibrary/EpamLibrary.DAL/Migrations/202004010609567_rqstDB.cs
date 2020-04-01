namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rqstDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentedBooks", "ReadingRoom", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentedBooks", "ReadingRoom");
        }
    }
}
