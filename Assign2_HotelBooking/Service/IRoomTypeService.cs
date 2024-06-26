using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRoomTypeService
    {
        List<RoomType> GetAll();
        RoomType GetById(int id);
        void Add(RoomType roomType);
        void Update(RoomType roomType);
        void Delete(int id);
    }
}
