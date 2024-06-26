using ModelAndDAL.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository _bookingDetailRepository;

        public BookingDetailService()
        {
            _bookingDetailRepository = new BookingDetailRepository();
        }

        public List<BookingDetail> GetAll()
        {
            return _bookingDetailRepository.GetAll();
        }

        public BookingDetail GetById(int id)
        {
            return _bookingDetailRepository.GetById(id);
        }

        public void Add(BookingDetail bookingDetail)
        {
            _bookingDetailRepository.Add(bookingDetail);
        }

        public void Update(BookingDetail bookingDetail)
        {
            _bookingDetailRepository.Update(bookingDetail);
        }

        public void Delete(int id)
        {
            _bookingDetailRepository.Delete(id);
        }
    }
}
