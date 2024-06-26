using ModelAndDAL.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFNguyenMinhDuc.ViewModels;

namespace WPFNguyenMinhDuc
{
    /// <summary>
    /// Interaction logic for CustomerProfile.xaml
    /// </summary>
    public partial class CustomerProfileView : Window
    {
        private readonly int _customerId;
        private readonly ICustomerService _customerService;

        public CustomerProfileView(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            _customerService = new CustomerService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Customer customer = _customerService.GetById(_customerId);

            // Fill each TextBox with the respective customer data
            FullNameTxt.Text = customer.CustomerFullName;
            TelephoneTxt.Text = customer.Telephone;
            EmailTxt.Text = customer.EmailAddress;
            PasswordBox.Password = customer.Password;
            BirthDayPicker.SelectedDate = DateTime.Parse(customer.CustomerBirthday.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = _customerService.GetById(_customerId);

            // Update the customer properties with the TextBox and PasswordBox values
            customer.CustomerFullName = FullNameTxt.Text;
            customer.Telephone = TelephoneTxt.Text;
            customer.EmailAddress = EmailTxt.Text;
            customer.CustomerBirthday = DateOnly.FromDateTime(BirthDayPicker.SelectedDate.GetValueOrDefault());
            customer.Password = PasswordBox.Password;

            // Call the method to update the customer profile using customerService.Update()
            _customerService.Update(customer);
        }
    }
}
