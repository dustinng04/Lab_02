using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelAndDAL.Models;
namespace Repository
{
    public interface IRoomInformationRepository
    {
        List<RoomInformation> GetAll();
        RoomInformation GetById(int id);
        void Add(RoomInformation RoomInformation);
        void Update(RoomInformation roomInformation);
        void Delete(int id);
        List<RoomInformation> GetByRoomNumber(String number);
    }
}
