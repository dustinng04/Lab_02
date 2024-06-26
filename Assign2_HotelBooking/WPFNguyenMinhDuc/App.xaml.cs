using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Repository;
using Service;
using System.IO;
using System.Windows;
using WPFNguyenMinhDuc.ViewModels;

namespace WPFNguyenMinhDuc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public IConfiguration Configuration { get; private set; }
        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ICustomerService, CustomerService>();
            // Add other services and repositories...
            // Register services
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IRoomInformationService, RoomInformationService>();
            services.AddSingleton<IBookingReservationService, BookingReservationService>();
            // Add other services...

            // Register view models
            services.AddTransient<AdminViewModel>();
            services.AddTransient<CustomerViewModel>();
            services.AddTransient<GeneralCustomerVM>();
            // Add other view models...

            // Register views
            services.AddTransient<AdminView>();
            services.AddTransient<ManageCustomersView>();
            services.AddTransient<ManageRoomsView>();
        }

        
    }

}
