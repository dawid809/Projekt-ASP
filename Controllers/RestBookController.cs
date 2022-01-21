using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_ASP.Enums;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP.Data;

namespace Projekt_ASP.Controllers
{
    [ApiController]
    [Route("/api/v1/books")]
    public class RestBookController : Controller
    {
        private readonly AppDbContext _context;
        public RestBookController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [DisableBasicAuthentication]
        [Route("{id}")]
        public IActionResult Get(int ?id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return BadRequest();
            }
            if (book.BookId > 5)
            {
                return NotFound();
            }

            return new OkObjectResult(book  
            //  = new Book()
            //{
            //    BookId = 1,
            //    Name = "TestBook",
            //    Author = new Author()
            //    {
            //        AuthorId = 1,
            //        FirstName = "TestJan",
            //        Lastname = "TestKowalski",
            //    },
            //    Category = new Category()
            //    {
            //        CategoryId = 1,
            //        BookCategory = BookCategories.History,
            //    },
            //    PageCount = 211,
            //    ReleaseDate = 2015
            //}
            );
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book.BookId > 5)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();

            // usuwa zasób
            return Ok($"Deleting book with id #{id}.");
        }

        [HttpGet]
        [DisableBasicAuthentication]
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get),
                new {id = book.BookId },
                book
                );
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, [FromBody] Book book)
        {
            if (id != book.BookId) return BadRequest();
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }

            catch
            {
                if (_context.Books.Find(id) == null)
                    return NotFound();
                throw;
            }
            return NoContent();
        }
        //deklaracja repo
        //[HttpGet]
        //public string Get() => "heelo";
        //[Route("{id}")]
        //public IActionResult Get(int ?id)
        //{
        //    if(id == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (id > 0 && id < 6)
        //    {
        //        Book book = new Book()
        //        {
        //            BookId = 1,
        //            Name = "Test",
        //            Author = new Author()
        //            {
        //                AuthorId = 1,
        //                FirstName = "Jan",
        //                Lastname = "Kowalski",
        //            },
        //            Category = new Category()
        //            {
        //                CategoryId = 1,
        //                BookCategory = BookCategories.History,
        //            },
        //            //Category = new Category()
        //            //{
        //            //    CategoryId = 1,
        //            //    BookCategory = (BookCategories)Enum.Parse(typeof(BookCategories), "Dramat"),
        //            //    //BookCategory = Enum.Parse(typeof Enum.BookCategories, Dramat),
        //            //    //BookCategory = (BookCategories)Enum.Parse(typeof(BookCategories), "Dramat")
        //            //    //BookCategory = (BookCategories)Enum.Parse(typeof(BookCategories), "Dramat".ToString()),
        //            //},
        //            PageCount = 211,
        //            ReleaseDate = 2015,
        //        };
        //        return book;
        //    }
        //    else
        //    {
        //       return NotFound();
        //    }
        //}
    }
}
