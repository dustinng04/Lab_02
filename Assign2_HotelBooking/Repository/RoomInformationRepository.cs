using ModelAndDAL.DbContexts;
using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        private readonly FuminiHotelManagementContext _context;

        public RoomInformationRepository()
        {
            _context = new FuminiHotelManagementContext();
        }

        public List<RoomInformation> GetAll()
        {
            return _context.RoomInformations.ToList();
        }

        public RoomInformation GetById(int id)
        {
            return _context.RoomInformations.FirstOrDefault(r => r.RoomId == id);
        }

        public void Add(RoomInformation room)
        {
            _context.RoomInformations.Add(room);
            _context.SaveChanges();
        }

        public void Update(RoomInformation room)
        {
            var existingRoom = GetById(room.RoomId);
            if (existingRoom != null)
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.RoomDetailDescription = room.RoomDetailDescription;
                existingRoom.RoomMaxCapacity = room.RoomMaxCapacity;
                existingRoom.RoomStatus = room.RoomStatus;
                existingRoom.RoomPricePerDay = room.RoomPricePerDay;
                existingRoom.RoomTypeId = room.RoomTypeId;

                _context.RoomInformations.Update(existingRoom);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var room = GetById(id);
            if (room != null)
            {
                room.RoomStatus = 2;
                Update(room);
                _context.SaveChanges();
            }
        }

        public List<RoomInformation> GetByRoomNumber(String roomNumber)
        {
            return _context.RoomInformations.Where(r => r.RoomNumber.Contains(roomNumber)).ToList();
        }
    }
}
