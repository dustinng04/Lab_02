using ModelAndDAL.Models;
using Repository;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public Customer AuthenticateCustomer(string email, string password)
        {
            return _repository.GetAll().FirstOrDefault(c => c.EmailAddress == email && c.Password == password);
        }

        public Customer GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Customer customer)
        {
            _repository.Add(customer);
        }

        public void Update(Customer customer)
        {
            _repository.Update(customer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Customer> GetByName(string name)
        {
            return _repository.GetByName(name);
        }
    }
}
