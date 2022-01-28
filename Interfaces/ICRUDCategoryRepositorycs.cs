using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Interfaces
{
    public interface ICRUDCategoryRepository
    {
        Category Find(int id);
        Category Delete(int id);
        Category Add(Category category);
        Category Update(Category category);

        IList<Category> FindAll();
    }
}
