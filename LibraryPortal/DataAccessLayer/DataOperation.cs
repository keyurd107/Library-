using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;

namespace DataAccessLayer
{
    public class DataOperation
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public UserDb ValidateUser(Login login)
        {
            try
            {
                // var User = _context.UserDb.Single(u => u.Id == login.Id);
                //var User = from u in _context.UserDb
                //           where u.Username.Equals(login.Username) &&
                //           u.Password.Equals(login.Password)
                //           select u;

                // var userDb = _context.UserDb.Where(u => u.Username.Equals(login.Username) && u.Password.Equals(login.Password)).FirstOrDefault();

                var userDb = _context.UserDb.Single(u => u.Username.Equals(login.Username)); ;

                if (userDb != null)
                {
                    if (userDb.Password.Equals(login.Password))
                        return userDb;
                }
                return null;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }
        public bool AddBook(Book book)
        {
            if (book.Title == null || book.Author == null || book.Price == 0)
            {
                return false;
            }

            else
            {

                BookDb ob = new BookDb();

                ob.Title = book.Title;
                ob.Author = book.Author;
                ob.Publish = book.Publish;
                ob.Price = book.Price;
                ob.Isbn = book.Isbn;

                _context.BookDb.Add(ob);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Book> GetAllBooks()
        {

            List<Book> newob = new List<Book>();
            var book = _context.BookDb.ToList();
            foreach (var b in book)
            {
                Book ob = new Book();
                ob.Id = b.Id;
                ob.Isbn = b.Isbn;
                ob.Author = b.Author;
                ob.Price = b.Price;
                ob.Publish = b.Publish;
                ob.Title = b.Title;
                newob.Add(ob);
            }
            return newob;

        }
        public bool DeleteBookFromDb(int id)
        {
            var getbook = _context.BookDb.Single(c => c.Id == id);
            _context.BookDb.Remove(getbook);
            _context.SaveChanges();
            return true;
        }

        public Book GetABook(int id)
        {
            var getbook = _context.BookDb.SingleOrDefault(c => c.Id == id);

            Book bk = new Book();

            bk.Id = getbook.Id;
            bk.Isbn = getbook.Isbn;
            bk.Title = getbook.Title;
            bk.Author = getbook.Author;
            bk.Publish = getbook.Publish;
            bk.Price = getbook.Price;

            return bk;
        
        }

        public bool UpdateBook(Book book)
        {
            var bookInDb = _context.BookDb.SingleOrDefault(c => c.Id == book.Id);

            bookInDb.Id = book.Id;
            bookInDb.Isbn = book.Isbn;
            bookInDb.Title = book.Title;
            bookInDb.Author = book.Author;
           // bookInDb.Publish = book.Publish;
            bookInDb.Price = book.Price;

            _context.SaveChanges();

            return true;
        }

    }
}
