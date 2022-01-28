using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Interfaces
{
    public interface ICRUDBookRepository
    {
        Book Find(int id);
        Book Delete(int id);
        Book Add(Book book);
        Book Update(Book book);

        IList<Book> FindAll();
    }
}
