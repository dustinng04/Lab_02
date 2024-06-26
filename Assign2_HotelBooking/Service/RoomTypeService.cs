using ModelAndDAL.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        public RoomTypeService()
        {
            _roomTypeRepository = new RoomTypeRepository();
        }

        public void Add(RoomType roomType) => _roomTypeRepository.Add(roomType);

        public void Delete(int id) => _roomTypeRepository.Delete(id);   

        public List<RoomType> GetAll() => _roomTypeRepository.GetAll();

        public RoomType GetById(int id) => _roomTypeRepository.GetById(id);

        public void Update(RoomType roomType) => _roomTypeRepository.Update(roomType);  

        
    }
}
