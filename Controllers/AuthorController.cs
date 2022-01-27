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

        public IActionResult Details(int id)
        {
            var author = repository.Find(id);
            return View(author);
        }

        public IActionResult Create()
        {
            return View(new Author());
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                repository.Add(author);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }

        public IActionResult Edit(int id)
        {
            var author = repository.Find(id);
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Author editAuthor)
        {
            if (ModelState.IsValid)
            {
                repository.Update(id, editAuthor);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        public IActionResult Delete(int id)
        {
            return View(repository.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
