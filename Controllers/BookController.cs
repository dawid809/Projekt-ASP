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
        static List<Book> booksList = new List<Book>();
   
            
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
    }
}
