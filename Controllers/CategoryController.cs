using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Interfaces;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
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

        public IActionResult Details(int id)
        {
            var category = repository.Find(id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

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

        public IActionResult Edit(int id)
        {
            return View(model: repository.Find(id));
        }

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
