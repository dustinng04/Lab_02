using ModelAndDAL.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookingReservationService : IBookingReservationService
    {
        private readonly IBookingReservationRepository _bookingReservationRepository;

        public BookingReservationService()
        {
            _bookingReservationRepository = new BookingReservationRepository();
        }

        public List<BookingReservation> GetAll()
        {
            return _bookingReservationRepository.GetAll();
        }

        public IEnumerable<BookingReservation> GetAllBookingsDesc()
        {
            return _bookingReservationRepository.GetAll().OrderByDescending(b => b.BookingDate);
        }

        public BookingReservation GetById(int id)
        {
            return _bookingReservationRepository.GetById(id);
        }

        public void Add(BookingReservation bookingReservation)
        {
            _bookingReservationRepository.Add(bookingReservation);
        }

        public void Update(BookingReservation bookingReservation)
        {
            _bookingReservationRepository.Update(bookingReservation);
        }

        public void Delete(int id)
        {
            _bookingReservationRepository.Delete(id);
        }

        public List<BookingReservation> GetBookingsByPeriod(DateOnly startDate, DateOnly endDate)
        {
            return GetAllBookingsDesc()
           .Where(b => b.BookingDetails.Any(d => d.StartDate >= startDate && d.EndDate <= endDate))
            .OrderByDescending(b => b.BookingDate)
            .ToList();
        }

        public List<BookingReservation> GetBookingHistory(int customerId)
        {
            return GetAllBookingsDesc()
                .Where(b => b.CustomerId == customerId)
                .ToList();
        }
    }
}
