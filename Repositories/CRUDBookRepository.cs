using Microsoft.EntityFrameworkCore;
using Projekt_ASP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class CRUDBookRepository : ICRUDBookRepository
    {
        private readonly AppDbContext _context;

        public CRUDBookRepository(AppDbContext context)
        {
            _context = context;
        }

        public Book Add(Book book)
        {
            var entity = _context.Books.Add(book).Entity;
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
