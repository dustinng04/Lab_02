using ModelAndDAL.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFNguyenMinhDuc.ViewModels;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFNguyenMinhDuc
{
    /// <summary>
    /// Interaction logic for ManageCustomersView.xaml
    /// </summary>
    public partial class ManageCustomersView : Window
    {
        private readonly ICustomerService _customerService;
        private Customer _selectedCustomer;

        public ManageCustomersView()
        {
            InitializeComponent();
            _customerService = new CustomerService();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            dgCustomers.ItemsSource = _customerService.GetAll();
            resetInput();
        }

        private void dgCustomers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedCustomer = (Customer)dgCustomers.SelectedItem;
            if (_selectedCustomer != null)
            {
                CustomerIdTextBox.Text = _selectedCustomer.CustomerId.ToString();
                CustomerFullNameTextBox.Text = _selectedCustomer.CustomerFullName;
                CustomerTelephoneTextBox.Text = _selectedCustomer.Telephone;
                CustomerEmailTextBox.Text = _selectedCustomer.EmailAddress;
                CustomerBirthdayPicker.SelectedDate = _selectedCustomer.CustomerBirthday?.ToDateTime(new TimeOnly());
                CustomerStatusComboBox.SelectedValue = _selectedCustomer.CustomerStatus;
                CustomerPasswordBox.Password = _selectedCustomer.Password;
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customer
            {
                CustomerFullName = CustomerFullNameTextBox.Text,
                Telephone = CustomerTelephoneTextBox.Text,
                EmailAddress = CustomerEmailTextBox.Text,
                CustomerBirthday = CustomerBirthdayPicker.SelectedDate.HasValue ? DateOnly.FromDateTime(CustomerBirthdayPicker.SelectedDate.Value) : null,
                CustomerStatus = (byte?)((ComboBoxItem)CustomerStatusComboBox.SelectedItem)?.Tag,
                Password = CustomerPasswordBox.Password
            };
            _customerService.Add(newCustomer);
            LoadCustomers();
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {
                _selectedCustomer.CustomerFullName = CustomerFullNameTextBox.Text;
                _selectedCustomer.Telephone = CustomerTelephoneTextBox.Text;
                _selectedCustomer.EmailAddress = CustomerEmailTextBox.Text;
                _selectedCustomer.CustomerBirthday = CustomerBirthdayPicker.SelectedDate.HasValue ? DateOnly.FromDateTime(CustomerBirthdayPicker.SelectedDate.Value) : null;
                _selectedCustomer.CustomerStatus = (byte?)((ComboBoxItem)CustomerStatusComboBox.SelectedItem)?.Tag;
                _selectedCustomer.Password = CustomerPasswordBox.Password;
                _customerService.Update(_selectedCustomer);
                LoadCustomers();
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {
                _customerService.Delete(_selectedCustomer.CustomerId);
                LoadCustomers();
            }
        }
        private void resetInput()
        {
            CustomerFullNameTextBox.Text = "";
            CustomerTelephoneTextBox.Text = "";
            CustomerEmailTextBox.Text = "";
            CustomerPasswordBox.Password = "";
            //CustomerBirthdayPicker.SelectedDate = "";
            CustomerStatusComboBox.SelectedValue = 0;
        }

        private void SearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = SearchCustomerTextBox.Text;
            var res = _customerService.GetByName(searchTerm);
            if (res != null) dgCustomers.ItemsSource = res;
            else
            {
                dgCustomers.ItemsSource = "";
                MessageBox.Show("Cannot find Customer with that name");
            }
        }
    }
}
