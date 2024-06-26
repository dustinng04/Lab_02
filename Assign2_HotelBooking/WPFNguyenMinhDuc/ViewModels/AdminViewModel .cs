using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFNguyenMinhDuc.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        public ICommand ManageRoomsCommand { get; }
        public ICommand CreateReportCommand { get; }
        public ICommand ManageCustomersCommand { get; }

        public AdminViewModel()
        {
            ManageRoomsCommand = new RelayCommand(OpenManageRooms);
            CreateReportCommand = new RelayCommand(OpenCreateReport);
            ManageCustomersCommand = new RelayCommand(OpenManageCustomers);
        }

        private void OpenManageRooms()
        {
            var manageRoomsView = new ManageRoomsView();
            manageRoomsView.ShowDialog();
        }

        private void OpenCreateReport()
        {
            var reportView = new ManageReportView();
            reportView.ShowDialog();
        }

        private void OpenManageCustomers()
        {
            var manageCustomersView = new ManageCustomersView();
            manageCustomersView.ShowDialog();
        }
    }

 
    
}
