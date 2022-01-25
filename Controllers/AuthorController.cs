using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ICRUDAuthorRepository repository;

        public AuthorController(ICRUDAuthorRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.FindAll());
        }

        // GET: AuthorController/Details/5
        public IActionResult Details(int id)
        {
            var author = repository.Find(id);
            return View(author);
        }

        // GET: AuthorController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                repository.Add(author);
                return View("Index", repository.FindAll());
            }
            else
            {
                return View("Create");
            }
        }

        //public IActionResult Edit(int id)
        //{
        //    //var newBook = repository.Find(id);
        //    return View(model: repository.Find(id));
        //}

        //[HttpPost]
        //public IActionResult Edit(Book newBook)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.Update(newBook);
        //        return View("BookList", repository.FindAll());
        //    }
        //    else
        //    {
        //        //return View("Edit", newBook);
        //        return View("Edit");
        //    }
        //}

        // GET: AuthorController/Edit/5
        public IActionResult Edit(int id)
        {
            return View(model: repository.Find(id));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author editAuthor)
        {
            if (ModelState.IsValid)
            {
                repository.Update(editAuthor);
                return View("Index", repository.FindAll());
            }
            else
            {
                //return View("Edit", newBook);
                return View("Edit");
            }
        }

        //GET: AuthorController/Delete/5
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return View("Index", repository.FindAll());
        }

        //// GET: AuthorController/Delete/5
        //public IActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AuthorController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
