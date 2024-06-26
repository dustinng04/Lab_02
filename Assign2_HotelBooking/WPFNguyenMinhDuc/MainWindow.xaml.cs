using System.IO;
using System.Windows;
using Newtonsoft.Json.Linq;
using Repository;
using Service;
namespace WPFNguyenMinhDuc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerService _customerService;

        private readonly string _adminEmail;
        private readonly string _adminPassword;

        public MainWindow() {
            InitializeComponent();
            _customerService = new CustomerService();

            // Load the admin credentials from appsettings.json
            var appSettings = JObject.Parse(File.ReadAllText("appsettings.json"));
            _adminEmail = appSettings["AdminAccount"]["Email"].ToString();
            _adminPassword = appSettings["AdminAccount"]["Password"].ToString();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            if (email == _adminEmail && password == _adminPassword)
            {
                // Admin login
                var adminView = new AdminView();
                adminView.Show();
                this.Close();
            }
            else
            {
                // Customer login
                var customer = _customerService.AuthenticateCustomer(email, password);
                if (customer != null)
                {
                    int customerId = customer.CustomerId;
                    var customerView = new CustomerView(customerId);
                    customerView.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}