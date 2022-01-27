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
        public RestBookController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int? id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return BadRequest();
            }
            return new OkObjectResult(book
            );
        }

        [HttpDelete]
        [Route("{id}")]
        [BasicAuthentication]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return BadRequest($"Object with id #{id} not exist.");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();

            // usuwa zasób
            return Ok($"Deleting book with id #{id}.");
        }

        [HttpGet]
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        [HttpPost]
        [BasicAuthentication]
        public IActionResult Post([FromBody] Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get),
                new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        [BasicAuthentication]
        public IActionResult Put(int id, [FromBody] Book book)
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
    }
}
