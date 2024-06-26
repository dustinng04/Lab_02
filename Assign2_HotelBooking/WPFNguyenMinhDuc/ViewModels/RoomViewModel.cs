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
    public class RoomViewModel : INotifyPropertyChanged
    {
        private readonly IRoomInformationService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private RoomInformation _selectedRoom;
        private string _searchTerm;

        public RoomViewModel()
        {
            _roomService = new RoomInformationService();
            _roomTypeService = new RoomTypeService();
            Rooms = new ObservableCollection<RoomInformation>(_roomService.GetAll());
            AddCommand = new RelayCommand(AddRoom);
            UpdateCommand = new RelayCommand(UpdateRoom);
            DeleteCommand = new RelayCommand(DeleteRoom);
            SearchCommand = new RelayCommand(SearchRooms);
        }
        public ObservableCollection<RoomInformation> Rooms { get; set; }
        public RoomInformation SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
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

        private void AddRoom()
        {
            // Implementation for adding a new room
            _roomService.Add(SelectedRoom);
            Rooms.Add(SelectedRoom);
            SelectedRoom = new RoomInformation();
        }

        private void UpdateRoom()
        {
            // Implementation for updating the selected room
            _roomService.Update(SelectedRoom);
        }

        private void DeleteRoom()
        {
            // Implementation for deleting the selected room
            _roomService.Delete(SelectedRoom.RoomId);
            Rooms.Remove(SelectedRoom);
        }

        private void SearchRooms()
        {
            Rooms.Clear();
            var result = _roomService.GetByRoomNumber(SearchTerm);
            foreach (var room in result) Rooms.Add(room);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

