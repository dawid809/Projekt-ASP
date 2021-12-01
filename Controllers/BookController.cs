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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBook(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.Add(book);
                return View("BookList", repository.FindAll());
            }
            else
            {
                return View("Add");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var newBook = repository.Find(id);
            return View(model: repository.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book newBook)
        {
            if (ModelState.IsValid)
            {
                repository.Update(newBook);
                return View("BookList", repository.FindAll());
            }
            else
            {
                //return View("Edit", newBook);
                return View("Edit");
            }
        }


        public IActionResult Description(int id)
        {
            var book = repository.Find(id);
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return View("BookList", repository.FindAll());
        }

        public IActionResult BookList()
        {
            return View(repository.FindAll());
        }
    }
}
