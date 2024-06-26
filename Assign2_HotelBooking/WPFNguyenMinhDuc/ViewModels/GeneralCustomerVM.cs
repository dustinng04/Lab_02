using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFNguyenMinhDuc.ViewModels
{
    public class GeneralCustomerVM
    {
        public ICommand ManageProfileCommand { get; }
        public ICommand ViewBookingHistoryCommand { get; }
        private readonly int _customerId;

        public GeneralCustomerVM(int customerId)
        {
            _customerId = customerId;
            ManageProfileCommand = new RelayCommand(OpenManageProfile);
            ViewBookingHistoryCommand = new RelayCommand(OpenViewBookingHistory);
        }

        private void OpenManageProfile()
        {
            var profileView = new CustomerProfileView(_customerId);
            profileView.Show();
        }

        private void OpenViewBookingHistory()
        {
            var bookingHistoryView = new BookingHistoryView(_customerId);
            bookingHistoryView.Show();
        }
    }
}
