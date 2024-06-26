using ModelAndDAL.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFNguyenMinhDuc.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;
        private Customer _selectedCustomer;
        private string _searchTerm;

        public CustomerViewModel()
        {
            _customerService = new CustomerService();
            Customers = new ObservableCollection<Customer>(_customerService.GetAll());
            AddCommand = new RelayCommand(AddCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer);
            DeleteCommand = new RelayCommand(DeleteCustomer);
            SearchCommand = new RelayCommand(SearchCustomers);
        }

        public ObservableCollection<Customer> Customers { get; set; }
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        private void AddCustomer()
        {
            // Implementation for adding a new customer
            _customerService.Add(SelectedCustomer);
            Customers.Add(SelectedCustomer);
            SelectedCustomer = new Customer();
        }

        private void UpdateCustomer()
        {
            // Implementation for updating the selected customer
            _customerService.Update(SelectedCustomer);
        }

        private void DeleteCustomer()
        {
            // Implementation for deleting the selected customer
            _customerService.Delete(SelectedCustomer.CustomerId);
            Customers.Remove(SelectedCustomer);
        }

        private void SearchCustomers()
        {
            Customers.Clear();
            var result = _customerService.GetByName(SearchTerm);
            foreach (var customer in result)
            {
                Customers.Add(customer);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
