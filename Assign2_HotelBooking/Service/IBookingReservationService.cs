using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBookingReservationService
    {
        List<BookingReservation> GetAll();
        BookingReservation GetById(int id);
        IEnumerable<BookingReservation> GetAllBookingsDesc();
        void Add(BookingReservation bookingReservation);
        void Update(BookingReservation bookingReservation);
        void Delete(int id);
        List<BookingReservation> GetBookingsByPeriod(DateOnly startDate, DateOnly endDate);
        List<BookingReservation> GetBookingHistory(int customerId);
    }
}
