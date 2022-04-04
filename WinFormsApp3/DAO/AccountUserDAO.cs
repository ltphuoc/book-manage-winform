using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Models;

namespace WinFormsApp3.Dao
{
    public class AccountUserDAO
    {
        private static AccountUserDAO instance = null;
        private static readonly object instanceLock = new object();

        public static AccountUserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountUserDAO();
                    }
                    return instance;
                }
            }
        }

        public AccountUser checkLogin(string username, string pasword)
        {
            AccountUser accountUser = null;
            try
            {
                using var context = new BookPublisherContext();
                accountUser = context.AccountUsers.SingleOrDefault(a => a.UserId == username && a.UserPassword == pasword);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return accountUser;
        }
    }
}
