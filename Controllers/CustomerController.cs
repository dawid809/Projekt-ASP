using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICRUDBookRepository repository;

        public CustomerController(ICRUDBookRepository repository)
        {
            this.repository = repository;
        }

        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.books = repository.FindAll();
            return View();
        }
    }
}
