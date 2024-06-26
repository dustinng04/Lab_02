using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail> GetAll();
        BookingDetail GetById(int id);
        void Add(BookingDetail detail);
        void Update(BookingDetail detail);  
        void Delete(int id);    
    }
}
