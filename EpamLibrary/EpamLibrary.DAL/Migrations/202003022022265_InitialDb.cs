namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ClientProfiles", name: "Id", newName: "ClientProfileId");
            RenameIndex(table: "dbo.ClientProfiles", name: "IX_Id", newName: "IX_ClientProfileId");
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAvaliable = c.Boolean(nullable: false),
                        ClientProfileId = c.Int(),
                        ClientProfile_ClientProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfile_ClientProfileId)
                .Index(t => t.ClientProfile_ClientProfileId);
            
            CreateTable(
                "dbo.RentedBooks",
                c => new
                    {
                        RentedBookId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        ClientProfileId = c.Int(nullable: false),
                        RentDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Penalty = c.Int(nullable: false),
                        ClientProfile_ClientProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RentedBookId)
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfile_ClientProfileId)
                .Index(t => t.ClientProfile_ClientProfileId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_BookId = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookId, t.Author_AuthorId })
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.Book_BookId)
                .Index(t => t.Author_AuthorId);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_GenreId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreId, t.Book_BookId })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Genre_GenreId)
                .Index(t => t.Book_BookId);
            
            AddColumn("dbo.ClientProfiles", "Email", c => c.String());
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.GenreBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "ClientProfile_ClientProfileId", "dbo.ClientProfiles");
            DropForeignKey("dbo.RentedBooks", "ClientProfile_ClientProfileId", "dbo.ClientProfiles");
            DropForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books");
            DropIndex("dbo.GenreBooks", new[] { "Book_BookId" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_GenreId" });
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthorId" });
            DropIndex("dbo.BookAuthors", new[] { "Book_BookId" });
            DropIndex("dbo.RentedBooks", new[] { "ClientProfile_ClientProfileId" });
            DropIndex("dbo.Books", new[] { "ClientProfile_ClientProfileId" });
            DropColumn("dbo.ClientProfiles", "Email");
            DropTable("dbo.GenreBooks");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Genres");
            DropTable("dbo.RentedBooks");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            RenameIndex(table: "dbo.ClientProfiles", name: "IX_ClientProfileId", newName: "IX_Id");
            RenameColumn(table: "dbo.ClientProfiles", name: "ClientProfileId", newName: "Id");
        }
    }
}
