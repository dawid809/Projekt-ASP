using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_ASP.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }

    public class EFBookRepository: IBookRepository
    {
        private ApplicationDbContext context;

        public EFBookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
