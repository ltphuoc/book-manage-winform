using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp3.DAO;
using WinFormsApp3.Models;

namespace WinFormsApp3
{
    public partial class UpdateForm : Form
    {
        BookPublisherContext db = new BookPublisherContext();
        public ManagerForm ParentForm { get; set; }
        private Book updateBook;
        public UpdateForm()
        {
            InitializeComponent();
        }
        public UpdateForm(Book book)
        {
            InitializeComponent();
            this.updateBook = book;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int quantity;
            if (int.TryParse(txtQuantity.Text, out quantity) == false)
            {
                MessageBox.Show("Quantity number");
            }
            else if (txtBookId.Text == "" || txtBookName.Text == "" || int.Parse(txtQuantity.Text) < 0
                || txtAuthorName.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("nhap het");
            }
            else if (txtAuthorName.Text.Length < 10)
            {
                MessageBox.Show("ten dai hon 10");

            }
            else if (txtBookName.Text.Length < 6 || txtBookName.Text.Length > 12)
            {
                MessageBox.Show("Name 6-12");
            }
            else
            {
                Book book = new Book()
                {
                    BookId = txtBookId.Text,
                    BookName = txtBookName.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    AuthorName = txtAuthorName.Text,
                    PublisherId = (string)comboBox1.SelectedItem,

                };
                bookDAO bDAO = new bookDAO();
                bDAO.Update(book);
                this.ParentForm.loadListBook();
                this.Close();
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            txtBookId.Text = updateBook.BookId;
            txtBookName.Text = updateBook.BookName;
            txtQuantity.Text = updateBook.Quantity.ToString(); 
            txtAuthorName.Text = updateBook.AuthorName;

            List<String> list = new List<string>();
            var publisher = db.Publishers.ToList();
            foreach (var x in publisher)
            {
                list.Add(x.PublisherId);
            }
            comboBox1.DataSource = list;
        }
    }
}
