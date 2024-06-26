using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetAll();
        BookingReservation GetById(int id);
        void Add(BookingReservation reservation);
        void Update(BookingReservation reservation);
        void Delete(int id);
    }
}
