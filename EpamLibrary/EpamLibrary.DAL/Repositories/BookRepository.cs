using EpamLibrary.DAL.EF;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.Tables.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EpamLibrary.DAL.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationContext _context;

        private readonly DbSet<Book> _dbSet;

        public BookRepository(ApplicationContext context) :base(context)
        {
            _context = context;
            _dbSet = context.Set<Book>();
        }

        public Book GetByName(string name)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Name == name);

            return entity;
        }
        public List<Author> GetAuthor()
        {
            var books = _dbSet.Where(b => b.Id == 1).FirstOrDefault();
            var author = books.Authors.ToList();
            return author;
        }
        public void CreateBook(Book item)
        {
            AuthorsGenresPublisher(item);
            _context.Books.Add(item);
            _context.SaveChanges();
        }
        public void UpdateBook(Book item)
        {
            //AuthorsGenresPublisher(item, true);
            Book tempB = GetById(item.Id);
            tempB.Name = item.Name;
            tempB.Quantity = item.Quantity;
            tempB.PublicationDate = item.PublicationDate;

            var authors = item.Authors.ToList();
            tempB.Authors.Clear();
            foreach (var author in authors)
            {
                var temp = _context.Authors.FirstOrDefault(a => a.Name == author.Name);
                if (temp == null)
                {
                    _context.Authors.Add(author);
                    _context.SaveChanges();
                    temp = _context.Authors.FirstOrDefault(a => a.Name == author.Name);
                }
                tempB.Authors.Add(temp);
            }

            var genres = item.Genres.ToList();
            tempB.Genres.Clear();
            foreach (var genre in genres)
            {
                var temp = _context.Genres.Where(a => a.Name == genre.Name).FirstOrDefault();
                if (temp == null)
                {
                    _context.Genres.Add(genre);
                    _context.SaveChanges();
                    temp = _context.Genres.Where(a => a.Name == genre.Name).FirstOrDefault();
                }
                tempB.Genres.Add(temp);
            }

            var publisher = item.Publisher;
            tempB.Publisher = null;
            var tempP = _context.Publishers.Where(p => p.Name == publisher.Name).FirstOrDefault();
            if (tempP == null)
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                tempP = _context.Publishers.Where(p => p.Name == publisher.Name).FirstOrDefault();
            }
            tempB.Publisher = tempP;
            Update(tempB);
        }
        public void AuthorsGenresPublisher(Book item)
        {
            var authors = item.Authors.ToList();
            item.Authors.Clear();
            foreach (var author in authors)
            {
                var temp = _context.Authors.FirstOrDefault(a => a.Name == author.Name);
                if (temp == null)
                {
                    _context.Authors.Add(author);
                    _context.SaveChanges();
                    temp = _context.Authors.FirstOrDefault(a => a.Name == author.Name);
                }
                item.Authors.Add(temp);
            }

            var genres = item.Genres.ToList();
            item.Genres.Clear();
            foreach (var genre in genres)
            {
                var temp = _context.Genres.Where(a => a.Name == genre.Name).FirstOrDefault();
                if (temp == null)
                {
                    _context.Genres.Add(genre);
                    _context.SaveChanges();
                    temp = _context.Genres.Where(a => a.Name == genre.Name).FirstOrDefault();
                }
                item.Genres.Add(temp);
            }

            var publisher = item.Publisher;
            item.Publisher = null;
            var tempP = _context.Publishers.Where(p => p.Name == publisher.Name).FirstOrDefault();
            if (tempP == null)
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                tempP = _context.Publishers.Where(p => p.Name == publisher.Name).FirstOrDefault();
            }
            item.Publisher = tempP;
        }
    }
}
