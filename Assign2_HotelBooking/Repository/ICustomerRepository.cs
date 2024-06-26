using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        List<Customer> GetByName(String name);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
