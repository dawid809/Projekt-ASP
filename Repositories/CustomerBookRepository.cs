//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Projekt_ASP.Models
//{
//    public interface ICustomerBookRepository
//    {
//        IList<Book> FindByName(string namePattern);
//        IList<Book> FindByAuthor(string autorName);
//        Book FindById(int id);
//    }
//    public class CustomerBookRepository : ICustomerBookRepository
//    {
//        private ApplicationDbContext context;

//        public CustomerBookRepository(ApplicationDbContext applicationDbContext)
//        {
//            context = applicationDbContext;
//        }

//        public IList<Book> FindByAuthor(string autorName)
//        {
//            throw new NotImplementedException();
//        }

//        public Book FindById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IList<Book> FindByName(string namePattern)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
