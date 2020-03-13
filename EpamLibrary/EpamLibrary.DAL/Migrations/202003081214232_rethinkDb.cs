namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rethinkDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_GenreId", "dbo.Genres");
            RenameColumn(table: "dbo.BookAuthors", name: "Book_BookId", newName: "Book_Id");
            RenameColumn(table: "dbo.BookAuthors", name: "Author_AuthorId", newName: "Author_Id");
            RenameColumn(table: "dbo.GenreBooks", name: "Genre_GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.GenreBooks", name: "Book_BookId", newName: "Book_Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_BookId", newName: "IX_Book_Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Author_AuthorId", newName: "IX_Author_Id");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_Genre_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_Book_BookId", newName: "IX_Book_Id");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.RentedBooks");
            DropPrimaryKey("dbo.Genres");
            DropColumn("dbo.Authors", "AuthorId");
            DropColumn("dbo.Books", "BookId");
            DropColumn("dbo.RentedBooks", "RentedBookId");
            DropColumn("dbo.Genres", "GenreId");
            AddColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Authors", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Books", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.RentedBooks", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RentedBooks", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Genres", "IsDeleted", c => c.Boolean(nullable: false));
            
            AddPrimaryKey("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Books", "Id");
            AddPrimaryKey("dbo.RentedBooks", "Id");
            AddPrimaryKey("dbo.Genres", "Id");
            AddForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "GenreId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RentedBooks", "RentedBookId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Books", "BookId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Authors", "AuthorId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.RentedBooks");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Authors");
            DropColumn("dbo.Genres", "IsDeleted");
            DropColumn("dbo.Genres", "Id");
            DropColumn("dbo.RentedBooks", "IsDeleted");
            DropColumn("dbo.RentedBooks", "Id");
            DropColumn("dbo.Books", "IsDeleted");
            DropColumn("dbo.Books", "Id");
            DropColumn("dbo.Authors", "IsDeleted");
            DropColumn("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Genres", "GenreId");
            AddPrimaryKey("dbo.RentedBooks", "RentedBookId");
            AddPrimaryKey("dbo.Books", "BookId");
            AddPrimaryKey("dbo.Authors", "AuthorId");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_Book_Id", newName: "IX_Book_BookId");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_Genre_Id", newName: "IX_Genre_GenreId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Author_Id", newName: "IX_Author_AuthorId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_Id", newName: "IX_Book_BookId");
            RenameColumn(table: "dbo.GenreBooks", name: "Book_Id", newName: "Book_BookId");
            RenameColumn(table: "dbo.GenreBooks", name: "Genre_Id", newName: "Genre_GenreId");
            RenameColumn(table: "dbo.BookAuthors", name: "Author_Id", newName: "Author_AuthorId");
            RenameColumn(table: "dbo.BookAuthors", name: "Book_Id", newName: "Book_BookId");
            AddForeignKey("dbo.GenreBooks", "Genre_GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.GenreBooks", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
    }
}
