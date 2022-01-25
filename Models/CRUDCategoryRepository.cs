using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public interface ICRUDCategoryRepository
    {
        Category Find(int id);
        Category Delete(int id);
        Category Add(Category category);
        Category Update(Category category);

        IList<Category> FindAll();
    }
    public class CRUDCategoryRepository : ICRUDCategoryRepository
    {
        private readonly AppDbContext _context;

        public CRUDCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            var entity = _context.Categories.Add(category).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Category Delete(int id)
        {
            var entity = _context.Categories.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Category Find(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public Category Update(Category category)
        {
            var entity = _context.Categories.Update(category).Entity;
            _context.SaveChanges();
            return entity;
        }

        public IList<Category> FindAll()
        {
            return _context.Categories.ToList();
        }
    }
}
