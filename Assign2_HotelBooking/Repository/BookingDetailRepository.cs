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
    public class BookingDetailRepository : IBookingDetailRepository
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingDetailRepository()
        {
            _context = new FuminiHotelManagementContext();
        }

        public List<BookingDetail> GetAll()
        {
            return _context.BookingDetails.ToList();
        }

        public BookingDetail GetById(int id)
        {
            return _context.BookingDetails.FirstOrDefault(b => b.BookingReservationId == id);
        }

        public void Add(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            _context.SaveChanges();
        }

        public void Update(BookingDetail bookingDetail)
        {
            var existingBookingDetail = GetById(bookingDetail.BookingReservationId);
            if (existingBookingDetail != null)
            {
                existingBookingDetail.BookingReservationId = bookingDetail.BookingReservationId;
                existingBookingDetail.RoomId = bookingDetail.RoomId;
                existingBookingDetail.StartDate = bookingDetail.StartDate;
                existingBookingDetail.EndDate = bookingDetail.EndDate;
                existingBookingDetail.ActualPrice = bookingDetail.ActualPrice;
                _context.BookingDetails.Update(existingBookingDetail);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var bookingDetail = GetById(id);
            if (bookingDetail != null)
            {
                _context.BookingDetails.Remove(bookingDetail);
                _context.SaveChanges();
            }
        }
    }
}
