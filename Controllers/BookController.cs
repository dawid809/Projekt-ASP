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
         List<Book> booksList = new List<Book>();
   
            
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Book()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddNewBook(Book book)
        {
            if (ModelState.IsValid)
            {
                booksList.Add(book);
                return View("BookList", booksList);
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult BookList()
        {
            booksList.Add(new Book { Name = "K1", Author = "Autor1" , BookDate = new DateTime(2008, 10, 31, 17, 4, 32), PageCount = 123} );
            return View("BookList", booksList);
        }
    }
}
