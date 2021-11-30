using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    public class BookController : Controller
    {

        private ICRUDBookRepository repository;

        public BookController(ICRUDBookRepository repository)
        {
            this.repository = repository;
        }
   
        public IActionResult Index()
        {
            return View(repository.FindAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddNewBook(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.Add(book);
                return RedirectToAction("BookList");
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult Edit(int id)
        {
            var newBook = repository.Find(id);
            repository.Delete(newBook.BookId);
            return View(newBook);
            //return RedirectToAction("newBook");
        }

        [HttpPost]
        public IActionResult Edit(Book newBook)
        {
            repository.Update(newBook);
            return RedirectToAction("BookList");
        }


        public IActionResult Description(int id)
        {
            var tmp = repository.Find(id);
            return View(tmp);
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("BookList");
        }

        public IActionResult BookList()
        {
            return View(repository.FindAll());
        }
    }
}
