using ModelAndDAL.DbContexts;
using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {

        private readonly FuminiHotelManagementContext _context;
        public RoomTypeRepository()
        {
            _context = new FuminiHotelManagementContext();
        }
        public List<RoomType> GetAll()
        {
            return _context.RoomTypes.ToList();
        }

        public RoomType GetById(int id)
        {
            return _context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeId == id);
        }

        public void Add(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            _context.SaveChanges();
        }

        public void Update(RoomType roomType)
        {
            var existingRoomType = GetById(roomType.RoomTypeId);
            if (existingRoomType != null)
            {
                existingRoomType.RoomTypeName = roomType.RoomTypeName;
                existingRoomType.TypeDescription = roomType.TypeDescription;
                existingRoomType.TypeNote = roomType.TypeNote;

                _context.RoomTypes.Update(existingRoomType);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var roomType = GetById(id);
            if (roomType != null)
            {
                _context.RoomTypes.Remove(roomType);
                _context.SaveChanges();
            }
        }
    }
}
