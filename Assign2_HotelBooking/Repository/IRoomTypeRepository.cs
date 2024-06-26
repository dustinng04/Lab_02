using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetAll();
        RoomType GetById(int id);
        void Add(RoomType roomType);
        void Update(RoomType roomType);
        void Delete(int id);
    }
}
