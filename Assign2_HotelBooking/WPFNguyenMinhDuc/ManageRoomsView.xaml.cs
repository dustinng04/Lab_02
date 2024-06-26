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

namespace WPFNguyenMinhDuc
{
    /// <summary>
    /// Interaction logic for ManageRoomsView.xaml
    /// </summary>
    public partial class ManageRoomsView : Window
    {
        private readonly IRoomInformationService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private RoomInformation _selectedRoom;

        public ManageRoomsView()
        {
            InitializeComponent();
            _roomService = new RoomInformationService();
            _roomTypeService = new RoomTypeService();
        }
        private void LoadRooms()
        {
            dgRooms.ItemsSource = _roomService.GetAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRooms();
            LoadRoomTypes();
        }

        private void LoadRoomTypes()
        {
            RoomTypeComboBox.ItemsSource = _roomTypeService.GetAll();
            RoomTypeComboBox.DisplayMemberPath = "RoomTypeName";
            RoomTypeComboBox.SelectedValuePath = "RoomTypeId";
        }

        private void dgRooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedRoom = (RoomInformation)dgRooms.SelectedItem;
            if (_selectedRoom != null)
            {
                RoomIdTextBox.Text = _selectedRoom.RoomId.ToString();
                RoomNumberTextBox.Text = _selectedRoom.RoomNumber;
                RoomDetailDescriptionTextBox.Text = _selectedRoom.RoomDetailDescription;
                RoomMaxCapacityTextBox.Text = _selectedRoom.RoomMaxCapacity.ToString();
                RoomStatusComboBox.SelectedValue = _selectedRoom.RoomStatus;
                RoomPricePerDayTextBox.Text = _selectedRoom.RoomPricePerDay.ToString();
                RoomTypeComboBox.SelectedValue = _selectedRoom.RoomTypeId;
            }
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            var newRoom = new RoomInformation
            {
                RoomNumber = RoomNumberTextBox.Text,
                RoomDetailDescription = RoomDetailDescriptionTextBox.Text,
                RoomMaxCapacity = int.TryParse(RoomMaxCapacityTextBox.Text, out int maxCapacity) ? maxCapacity : (int?)null,
                RoomStatus = (byte?)((ComboBoxItem)RoomStatusComboBox.SelectedItem).Tag,
                RoomPricePerDay = decimal.TryParse(RoomPricePerDayTextBox.Text, out decimal pricePerDay) ? pricePerDay : (decimal?)null,
                RoomTypeId = (int)RoomTypeComboBox.SelectedValue
            };
            _roomService.Add(newRoom);
            LoadRooms();
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom != null)
            {
                _selectedRoom.RoomNumber = RoomNumberTextBox.Text;
                _selectedRoom.RoomDetailDescription = RoomDetailDescriptionTextBox.Text;
                _selectedRoom.RoomMaxCapacity = int.TryParse(RoomMaxCapacityTextBox.Text, out int maxCapacity) ? maxCapacity : (int?)null;
                _selectedRoom.RoomStatus = byte.TryParse(((ComboBoxItem)RoomStatusComboBox.SelectedItem)?.Tag.ToString(), out byte result) ? (byte?)result : null;

                _selectedRoom.RoomPricePerDay = decimal.TryParse(RoomPricePerDayTextBox.Text, out decimal pricePerDay) ? pricePerDay : (decimal?)null;
                _selectedRoom.RoomTypeId = (int)RoomTypeComboBox.SelectedValue;
                _roomService.Update(_selectedRoom);
                LoadRooms();
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom != null)
            {
                _roomService.Delete(_selectedRoom.RoomId);
                LoadRooms();
            }
        }

        private void SearchRoom_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = SearchRoomTextBox.Text;
            var res = _roomService.GetByRoomNumber(searchTerm);
            if (res != null) {
                dgRooms.ItemsSource = res;
            } else
            {
                MessageBox.Show("Cannot find room with that number");
                dgRooms.ItemsSource = "";
            }
        }

    }
}
