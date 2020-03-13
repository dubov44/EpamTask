namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookBd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Name", c => c.String());
        }
    }
}
