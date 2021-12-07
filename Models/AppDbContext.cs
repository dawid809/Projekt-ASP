using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Projekt_ASP.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }

    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    public class EFBookRepository: IBookRepository
    {
        private AppDbContext context;

        public EFBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
