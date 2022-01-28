using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP.Interfaces;
using Projekt_ASP.Models;

namespace Projekt_ASP.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class BookController : Controller
    {
        private readonly ICRUDBookRepository repository;

        public BookController(ICRUDBookRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var books = repository.FindAll();
            return View(books);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = repository.FindAll().FirstOrDefault(x => x.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult Create([FromServices] ICRUDAuthorRepository authorRepository, [FromServices] ICRUDCategoryRepository categoryRepository)
        {
            ViewData["AuthorId"] = new SelectList(authorRepository.FindAll(), "AuthorId", "FullName");
            ViewData["CategoryId"] = new SelectList(categoryRepository.FindAll(), "CategoryId", "BookCategory");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BookId,Name,PageCount,ReleaseDate,AuthorId,CategoryId,Price, Quantity")] Book book, [FromServices] ICRUDAuthorRepository authorRepository, [FromServices] ICRUDCategoryRepository categoryRepository)
        {
            if (ModelState.IsValid)
            {
                repository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(authorRepository.FindAll(), "AuthorId", "FullName", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(categoryRepository.FindAll(), "CategoryId", "BookCategory", book.CategoryId);
            return View(book);
        }

        public IActionResult Edit(int id, [FromServices] ICRUDAuthorRepository authorRepository, [FromServices] ICRUDCategoryRepository categoryRepository)
        {
            var book = repository.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(authorRepository.FindAll(), "AuthorId", "FullName", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(categoryRepository.FindAll(), "CategoryId", "BookCategory", book.CategoryId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BookId,Name,PageCount,ReleaseDate,AuthorId,CategoryId,Price, Quantity")] Book book, [FromServices] ICRUDAuthorRepository authorRepository, [FromServices] ICRUDCategoryRepository categoryRepository, [FromServices] AppDbContext appDb)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId, appDb))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(authorRepository.FindAll(), "AuthorId", "FullName", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(categoryRepository.FindAll(), "CategoryId", "BookCategory", book.CategoryId);
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = repository.FindAll().FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = repository.Find(id).BookId;
            repository.Delete(book);
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id, [FromServices] AppDbContext book)
        {
            return book.Books.Any(e => e.BookId == id);
        }
    }
}


