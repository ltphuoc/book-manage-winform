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
    public partial class ManagerForm : Form
    {
        BookPublisherContext db = new BookPublisherContext();
        //private AccountUser accountUser;
        public ManagerForm()
        {
            InitializeComponent();
        }

        public void loadListBook()
        {
            bookDAO bookDAO = new bookDAO();
            var books = bookDAO.GetBookList();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = books;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            loadListBook();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Khong chon sao ma xoa duoc");
            }else
            {
                string id = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                if (MessageBox.Show(string.Format("Delete this id {0}", id), "confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bookDAO bDAO = new bookDAO();
                    bDAO.Remove(id);
                    loadListBook();
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ParentForm = this;
            addForm.ShowDialog();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
            bookDAO bookDAO = new bookDAO();
            var book = bookDAO.GetBookByID(id);
            UpdateForm uf = new UpdateForm(book);
            uf.ParentForm = this;
            uf.ShowDialog();
        }
    }
}
