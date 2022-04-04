using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp3.Dao;
using WinFormsApp3.Models;

namespace WinFormsApp3
{   
    
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        BookPublisherContext db = new BookPublisherContext();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            AccountUserDAO auDAO = new AccountUserDAO();
            var user = auDAO.checkLogin(username, password);
            if(user == null)
            {
                MessageBox.Show("Kh cho vo day nhoc con");
            }
            else
            {
                if(user.UserRole == 1 || user.UserRole == 2)
                {
                    Program.manager = new ManagerForm();
                    Program.manager.ShowDialog();
                    Program.currentUser = user;
                    this.Close();
                }else
                {
                    MessageBox.Show("Khong duoc vao");
                    Program.currentUser = null;
                    
                }
            }
            
        }
    }
}
