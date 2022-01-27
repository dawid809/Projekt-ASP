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

    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
    }

    public interface IAuthorRepository
    {
        IQueryable<Author> Authors { get; }
    }


    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Book.ModelCreate(builder);
            Category.ModelCreate(builder);
            Author.ModelCreate(builder);
        }
    }

    public class EFBookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public EFBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Book> Books => context.Books;
        public IQueryable<Category> Categories => context.Categories;
        public IQueryable<Author> Authors => context.Authors;
    }
}
