using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRoomInformationService
    {
        List<RoomInformation> GetAll();
        RoomInformation GetById(int id);
        void Add(RoomInformation roomInformation);
        void Update(RoomInformation roomInformation);
        void Delete(int id);
        List<RoomInformation> GetByRoomNumber(String number);
    }
}
