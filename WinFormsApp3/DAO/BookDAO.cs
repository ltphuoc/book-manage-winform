using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Models;

namespace WinFormsApp3.DAO
{
    
    public class bookDAO
    {
        private static bookDAO instance = null;
        private static bookDAO instanceLock = new bookDAO();

        public static bookDAO Instance
        {
            get
            {
                lock(instanceLock)
                {
                   if(instance == null)
                    {
                        instance = new bookDAO();
                    }
                   return instance;
                }
            }
        }

        public IEnumerable<Book> GetBookList()
        {
            var books = new List<Book>();
            try
            {
                using var context = new BookPublisherContext();
                books = context.Books.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return books;
        }

        public Book GetBookByID(String bookId)
        {
            Book book = null;
            try
            {
                using var context = new BookPublisherContext();
                book = context.Books.SingleOrDefault(x => x.BookId == bookId);
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            return book;
        }

        public void AddNew (Book book)
        {
            try
            {
                Book _book = GetBookByID(book.BookId);
                if(_book == null)
                {
                    using var context = new BookPublisherContext();
                    context.Books.Add(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This book already existed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Update(Book book)
        {
            try
            {
                Book _book = GetBookByID(book.BookId);
                if (_book != null)
                {
                    using var context = new BookPublisherContext();
                    context.Books.Update(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This book is not existed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(string bookId)
        {
            try
            {
                Book book = GetBookByID(bookId);
                if(book != null)
                {
                    using var context = new BookPublisherContext();
                    context.Books.Remove(book);
                    context.SaveChanges ();
                }else
                {
                    throw new Exception("Not existed.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }
    }
}
