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

        //private IBookRepository repository;
        //public BookController(IBookRepository repository)
        //{
        //    this.repository = repository;
        //}

        private ICRUDBookRepository repository;
        public BookController(ICRUDBookRepository repository)
        {
            this.repository = repository;
        }


        //public ViewResult Indexx()
        //{
        //    return View(repository.Books);
        //}


        private static List<Book> booksList = new List<Book>() 
          {
              //new Book()
              //{
              //    Id = 1, Author = "Bolesław Prus", ReleaseDate = 2015 , Name = "Lalka", PageCount = 864
              //},
              //new Book()
              //{
              //    Id = 2, Author = "Jan Brzechwa", ReleaseDate = 2013 , Name = "Akademia Pana Kleksa", PageCount = 136
              //},
          };
   
            
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
                return View("BookList");
            }
            else
            {
                return View("Add");
            }
        }

        //public IActionResult Edit(int id)
        //{
        //    //var tmp = booksList.FirstOrDefault(x => x.Id == id);
        //    var newBook = booksList.Where(x => x.Id == id).FirstOrDefault();
        //    return View(newBook);
        //}

        //[HttpPost]
        //public IActionResult Edit(Book newBook)
        //{
        //    var book = booksList.Where(x => x.Id == newBook.Id).FirstOrDefault();
        //    booksList.Remove(book);
        //    booksList.Add(newBook);
        //    return View("BookList", booksList);
        //}

        ////public IActionResult Save(Book newBook)
        ////{
        ////    var book = booksList.Where(x => x.Id == newBook.Id).FirstOrDefault();
        ////    booksList.Remove(book);
        ////    booksList.Add(newBook);
        ////    return View("BookList", booksList);
        ////}

        //public IActionResult Description(int id)
        //{
        //    var tmp = booksList.FirstOrDefault(x => x.Id == id);
        //    return View(tmp);
        //}

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            //return View("BookList", booksList);
            return Index();
        }

        public IActionResult BookList()
        {
            return View(repository.FindAll());
        }
    }
}
