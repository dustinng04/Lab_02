using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GetAll();
        BookingDetail GetById(int id);
        void Add(BookingDetail bookingDetail);
        void Update(BookingDetail bookingDetail);
        void Delete(int id);
    }
}
