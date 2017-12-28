using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using CommonLayer.ViewModel;
using DataAccessLayer;

namespace BussinessLayer
{
    public class UserAuthenticate
    {
        DataOperation op = new DataOperation();
        public Login Authenticate(Login login )
        {
            Login loginObj = new Login();

            var userDb = op.ValidateUser(login);

            if (userDb != null)
            {
                loginObj.Id = userDb.Id;
                loginObj.Username = userDb.Username;
                loginObj.Password = userDb.Password;
                loginObj.Roles = userDb.Roles;

                return loginObj;
            }
            return null;
        }

        public bool InsertBookInDb(Book book)
        {
            if (op.AddBook(book))
                return true;
            return false;

        }

        public List<Book> viewAllBooks()
        {
            return op.GetAllBooks();
        }

        public bool DeleteBook(int id)
        {
            op.DeleteBookFromDb(id);
            return true;
        }

        public Book GetABookFromDb(int id)
        {
            return op.GetABook(id);
        }

        public bool UpdateBookInDb(Book book)
        {

            op.UpdateBook(book);
            return true;
        }
    }
}
