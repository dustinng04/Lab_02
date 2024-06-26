using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPFNguyenMinhDuc
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ManageReportView : Window
    {
        private readonly IBookingReservationService _bookingReservationService;

        public ManageReportView()
        {
            InitializeComponent();
            _bookingReservationService = new BookingReservationService();
            LoadAllBookings();
        }
        private void LoadAllBookings()
        {
            var bookings = _bookingReservationService.GetAll();
            dgBookings.ItemsSource = bookings;
        }

        private void FilterBookings_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDateTime = dpStartDate.SelectedDate;
            DateTime? endDateTime = dpEndDate.SelectedDate;

            if (startDateTime.HasValue && endDateTime.HasValue)
            {
                DateOnly startDate = DateOnly.FromDateTime(startDateTime.Value);
                DateOnly endDate = DateOnly.FromDateTime(endDateTime.Value);

                var filteredBookings = _bookingReservationService.GetBookingsByPeriod(startDate,endDate);
                dgBookings.ItemsSource = filteredBookings;
                Debug.WriteLine($"Filtered Bookings Count: {filteredBookings.Count}");
            }
            else
            {
                MessageBox.Show("Please select both start and end dates.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
