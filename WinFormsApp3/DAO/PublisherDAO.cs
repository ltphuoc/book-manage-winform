using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.DAO
{
    public class PublisherDAO
    {
        private static PublisherDAO instance = null;
        private static PublisherDAO instanceLock = new PublisherDAO();

        public static PublisherDAO Instace
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PublisherDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
