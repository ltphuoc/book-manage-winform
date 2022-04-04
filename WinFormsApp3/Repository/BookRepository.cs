using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.DAO;
using WinFormsApp3.Models;

namespace WinFormsApp3.Repository
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBookList() => bookDAO.Instance.GetBookList();
        public Book GetBookById(string bookId) => bookDAO.Instance.GetBookByID(bookId);
        public void AddNew(Book book) => bookDAO.Instance.AddNew(book);
        public void Update(Book book) => bookDAO.Instance.Update(book);
        public void Remove(string bookId) => bookDAO.Instance.Remove(bookId);
    }
}
