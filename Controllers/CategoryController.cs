using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICRUDCategoryRepository repository;

        public CategoryController(ICRUDCategoryRepository repository)
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
            var category = repository.Find(id);
            return View(category);
        }

        // GET: AuthorController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.Add(category);
                return View("Index", repository.FindAll());
            }
            else
            {
                return View("Create");
            }
        }

        // GET: AuthorController/Edit/5
        public IActionResult Edit(int id)
        {
            return View(model: repository.Find(id));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category editCategory)
        {
            if (ModelState.IsValid)
            {
                repository.Update(editCategory);
                return View("Index", repository.FindAll());
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
