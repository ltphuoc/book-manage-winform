using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Dao;
using WinFormsApp3.Models;

namespace WinFormsApp3.Repository
{
    public class AccountRepository
    {
        public AccountUser Login(string username, string password) => AccountUserDAO.Instance.checkLogin(username, password);  

    }
}
