using ModelAndDAL.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoomInformationService : IRoomInformationService
    {
        private readonly IRoomInformationRepository _roomInformationRepository;

        public RoomInformationService()
        {
            _roomInformationRepository = new RoomInformationRepository();
        }

        public List<RoomInformation> GetAll()
        {
            return _roomInformationRepository.GetAll();
        }

        public RoomInformation GetById(int id)
        {
            return _roomInformationRepository.GetById(id);
        }

        public void Add(RoomInformation roomInformation)
        {
            _roomInformationRepository.Add(roomInformation);
        }

        public void Update(RoomInformation roomInformation)
        {
            _roomInformationRepository.Update(roomInformation);
        }

        public void Delete(int id)
        {
            _roomInformationRepository.Delete(id);
        }

        public List<RoomInformation> GetByRoomNumber(String number)
        {
            return _roomInformationRepository.GetByRoomNumber(number);
        }
    }
}
