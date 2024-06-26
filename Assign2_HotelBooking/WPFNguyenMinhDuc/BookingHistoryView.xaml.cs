using ModelAndDAL.Models;
using Repository;
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

namespace WPFNguyenMinhDuc
{
    /// <summary>
    /// Interaction logic for BookingHistoryView.xaml
    /// </summary>
    public partial class BookingHistoryView : Window
    {
        private readonly int _customerId;
        private readonly IBookingReservationService _bookingReservationService;

        public BookingHistoryView(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            _bookingReservationService = new BookingReservationService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            // Retrieve booking history for the customer
            var bookingList = _bookingReservationService.GetBookingHistory(_customerId);

            BookingHistoryGrid.ItemsSource = bookingList;
        }
    }
}
