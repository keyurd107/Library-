using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;

namespace LibraryPortal.Controllers
{
    
    public class BookController : Controller
    {
        UserAuthenticate ua = new UserAuthenticate();

        // GET: Book

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddBook(Book book)
        {
            if (book.Id == 0)
            {
                ua.InsertBookInDb(book);
            }
            else
            {
                ua.UpdateBookInDb(book);
            }

            //return RedirectToAction("DisplayBooks", "Book");
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayBooks()
        {
            var model = ua.viewAllBooks();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            ua.DeleteBook(id);

            // return RedirectToAction("DisplayBooks", "Book");
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            var book =  ua.GetABookFromDb(id);
            //return View("Create",book);
            return Json(book, JsonRequestBehavior.AllowGet);
        }
    }
}