using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Interfaces;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly ICRUDBookRepository repository;

        public CartController(ICRUDBookRepository repository)
        {
            this.repository = repository;
        }

        [Route("Index")]
        public IActionResult Index()
        {

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Book.Price * item.Quantity);
            return View();
        }

        [Route("Buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>();
                cart.Add(new Item() { Book = repository.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);

                if (index == -1)
                {
                    cart.Add(new Item() { Book = repository.Find(id), Quantity = 1 });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Book.BookId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
