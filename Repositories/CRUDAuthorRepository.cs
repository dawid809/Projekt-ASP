using Projekt_ASP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class CRUDAuthorRepository : ICRUDAuthorRepository
    {
        private readonly AppDbContext _context;

        public CRUDAuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Author Add(Author author)
        {
            var entity = _context.Authors.Add(author).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Author Delete(int id)
        {
            var entity = _context.Authors.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Author Find(int id)
        {
            return _context.Authors.FirstOrDefault(x => x.AuthorId == id);
        }

        public Author Update(int id, Author author)
        {
            var entity = _context.Authors.Find(id);
            if (entity != null)
            {
                entity.FirstName = author.FirstName;
                entity.Lastname = author.Lastname;
            }
            _context.SaveChanges();
            return entity;
        }

        public IList<Author> FindAll()
        {
            return _context.Authors.ToList();
        }
    }
}