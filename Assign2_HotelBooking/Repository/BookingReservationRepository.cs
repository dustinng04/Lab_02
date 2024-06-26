using Microsoft.EntityFrameworkCore;
using ModelAndDAL.DbContexts;
using ModelAndDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        private readonly FuminiHotelManagementContext _context;
        public BookingReservationRepository()
        {
            _context = new FuminiHotelManagementContext();
        }

        public void Add(BookingReservation reservation) { 
            _context.BookingReservations.Add(reservation); 
            _context.SaveChanges();
        }


        public void Delete(int id) {
            var found = GetById(id);
            if (found != null)
            {
                _context.BookingReservations.Remove(found);
                _context.SaveChanges();
            }
        } 

        public BookingReservation GetById(int id)
        {
            return _context.BookingReservations.FirstOrDefault(b => b.BookingReservationId == id);
        }

        public List<BookingReservation> GetAll()
        {
            return _context.BookingReservations.Include(b => b.BookingDetails).ToList();
        }

        public void Update(BookingReservation reservation)
        {
            var existingBookReservation = GetById(reservation.BookingReservationId);
            if (existingBookReservation != null) {
                existingBookReservation.BookingReservationId = reservation.BookingReservationId;
                existingBookReservation.CustomerId = reservation.CustomerId;
                existingBookReservation.BookingDate = reservation.BookingDate;
                existingBookReservation.TotalPrice = reservation.TotalPrice;
                existingBookReservation.BookingStatus = reservation.BookingStatus;

                _context.BookingReservations.Update(existingBookReservation);
                _context.SaveChanges();
            }
        }

    }
}
