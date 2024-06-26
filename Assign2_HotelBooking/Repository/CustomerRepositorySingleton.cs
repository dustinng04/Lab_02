using ModelAndDAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepositorySingleton
    {
        private static CustomerRepository _instance;
        private static readonly object _lock = new object();

        private CustomerRepositorySingleton() { }

        public static CustomerRepository Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CustomerRepository();
                    }
                }
                return _instance;
            }
        }
    }
}
