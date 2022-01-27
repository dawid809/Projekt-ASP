using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public interface ICRUDBookRepository
    {
        Book Find(int id);
        Book Delete(int id);
        Book Add(AddBook book);
        Book Update(Book book);

        IList<Book> FindAll();
    }

    public class CRUDBookRepository : ICRUDBookRepository
    {
        private readonly AppDbContext _context;

        public CRUDBookRepository(AppDbContext context)
        {
            _context = context;
        }

        public Book Add(AddBook book)
        {
            var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == book.CategoryId);
            var aut = _context.Authors.FirstOrDefault(x => x.FirstName == book.FirstName && x.Lastname == book.LastName);
            if (aut == null)
            {
                aut = _context.Authors.Add(new Author { FirstName = book.FirstName, Lastname = book.LastName }).Entity;
            }
            var entity = _context.Books.Add(new Book { Author = aut, Category = cat, Name = book.Name, PageCount = book.PageCount, ReleaseDate = book.ReleaseDate }).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Book Delete(int id)
        {
            var entity = _context.Books.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Book Find(int id)
        {
            return _context.Books.FirstOrDefault(x => x.BookId == id);
        }

        public Book Update(Book book)
        {
            var entity = _context.Books.Update(book).Entity;
            _context.SaveChanges();
            return entity;
        }

        public IList<Book> FindAll()
        {
            return _context.Books.Include(a => a.Author).Include(a => a.Category).ToList();
        }
    }
}
