using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Interfaces
{
    public interface ICRUDAuthorRepository
    {
        Author Find(int id);
        Author Delete(int id);
        Author Add(Author author);
        Author Update(int id, Author author);

        IList<Author> FindAll();
    }
}
