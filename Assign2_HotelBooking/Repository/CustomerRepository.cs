using ModelAndDAL.DbContexts;
using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FuminiHotelManagementContext _context;

        public CustomerRepository()
        {
            _context = new FuminiHotelManagementContext();
        }
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerFullName = customer.CustomerFullName;
                existingCustomer.Telephone = customer.Telephone;
                existingCustomer.EmailAddress = customer.EmailAddress;
                existingCustomer.CustomerBirthday = customer.CustomerBirthday;
                existingCustomer.CustomerStatus = customer.CustomerStatus;
                existingCustomer.Password = customer.Password;

                _context.Customers.Update(existingCustomer);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                customer.CustomerStatus = 2;
                Update(customer);
                _context.SaveChanges();
            }
        }

        public List<Customer> GetByName(string name)
        {
            return _context.Customers.Where(c => c.CustomerFullName.Contains(name)).ToList();
        }
    }
}
