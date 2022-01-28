using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Item
    {
        //private Book book = new Book();

        //public Book Book
        //{
        //    get { return book; }
        //    set { book = value; }
        //}

        //private int quantity;

        //public int Quantity
        //{
        //    get { return quantity; }
        //    set { quantity = value; }
        //}

        //public Item() { }

        //public Item(Book book, int quantity)
        //{
        //    this.book = book;
        //    this.quantity = quantity;
        //}
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
