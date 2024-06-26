using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        List<Customer> GetByName(string name);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        Customer AuthenticateCustomer(String email, String password);
    }
}
