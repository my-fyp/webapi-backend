using Home_Sewa.Data;
using Home_Sewa.Helper;
using Home_Sewa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class BookingService
    {
        private readonly HomeSewaDbContext _dbContext;

        public BookingService(HomeSewaDbContext Db)
        {
            _dbContext = Db;

        }
        internal object GetAllBooking(int userId, string userType, bool completedStatus)
        {
            if (userType == Constants.CUSTOMER)
            {
                return _dbContext.Bookings
                    .Where(b => b.CustomerId == userId && b.CompletedStatus == completedStatus)
                    .OrderByDescending(d => d.ServiceDate)
                    .Select(u => new
                    {
                        u.BookingId,
                        u.BookingDate,
                        u.ServiceDate,
                        u.ProblemDescription,
                        u.ServiceType,
                        u.ServiceAddress,
                        u.BookedBy,
                        u.IsAccepted,
                        u.Vendor.VendorId,
                        VendorName = u.Vendor.Name,
                        VendorImage = u.Vendor.ProfileImage,
                        VendorContact = u.Vendor.PhoneNo,
                        u.Customer.CustomerId,
                        CustomerName = u.Customer.Name,
                        CustomerImage = u.Customer.ProfileImage,
                        CustomerContact = u.Customer.PhoneNo,

                    });
            }
            else if (userType == Constants.VENDOR)
            {
                return _dbContext.Bookings
                    .Where(b => (b.VendorId == userId || (b.CustomerId == userId && b.BookedBy == userType)) && b.CompletedStatus == completedStatus)
                    .OrderByDescending(d => d.ServiceDate)
                    .Select(u => new
                    {
                        u.BookingId,
                        u.BookingDate,
                        u.ServiceDate,
                        u.ProblemDescription,
                        u.ServiceType,
                        u.ServiceAddress,
                        u.BookedBy,
                        u.IsAccepted,
                        u.Vendor.VendorId,
                        VendorName = u.Vendor.Name,
                        VendorImage = u.Vendor.ProfileImage,
                        VendorContact = u.Vendor.PhoneNo,
                        u.Customer.CustomerId,
                        CustomerName = u.Customer.Name,
                        CustomerImage = u.Customer.ProfileImage,
                        CustomerContact = u.Customer.PhoneNo,

                    });
            }
            else
            {
                return "User not found";
            }
        }

        internal object GetBookingRequests(int userId, string userType)
        {
            if (userType == Constants.CUSTOMER)
            {
                return _dbContext.Bookings
                    .Where(b => b.CustomerId == userId && b.IsAccepted == false)
                    .OrderByDescending(d => d.ServiceDate)
                     .Select(u => new
                     {
                         u.BookingId,
                         u.BookingDate,
                         u.ServiceDate,
                         u.ProblemDescription,
                         u.ServiceType,
                         u.BookedBy,
                         u.IsAccepted,
                         u.ServiceAddress,
                         u.Vendor.VendorId,
                         VendorName = u.Vendor.Name,
                         VendorImage = u.Vendor.ProfileImage,
                         VendorContact = u.Vendor.PhoneNo,
                         u.Customer.CustomerId,
                         CustomerName = u.Customer.Name,
                         CustomerImage = u.Customer.ProfileImage,
                         CustomerContact = u.Customer.PhoneNo,

                     });
            }
            else if (userType == Constants.VENDOR)
            {
                return _dbContext.Bookings
                    .Where(b => (b.VendorId == userId || (b.CustomerId == userId && b.BookedBy == userType)) && b.IsAccepted == false)
                    .OrderByDescending(d => d.ServiceDate)
                     .Select(u => new
                     {
                         u.BookingId,
                         u.BookingDate,
                         u.ServiceDate,
                         u.ProblemDescription,
                         u.ServiceType,
                         u.ServiceAddress,
                         u.BookedBy,
                         u.IsAccepted,
                         u.Vendor.VendorId,
                         VendorName = u.Vendor.Name,
                         VendorImage = u.Vendor.ProfileImage,
                         VendorContact = u.Vendor.PhoneNo,
                         u.Customer.CustomerId,
                         CustomerName = u.Customer.Name,
                         CustomerImage = u.Customer.ProfileImage,
                         CustomerContact = u.Customer.PhoneNo,

                     });
            }
            else
            {
                return "User not found";
            }
        }

        internal object MakeBookingRequest(BookingRequest bookingRequest)
        {
            try
            {
                Booking new_booking = new Booking
                {
                    CustomerId = bookingRequest.CustomerId,
                    VendorId = bookingRequest.VendorId,
                    BookingDate = DateTime.Now,
                    CompletedStatus = bookingRequest.CompletedStatus,
                    Discount = bookingRequest.Discount,
                    TotalPrice = bookingRequest.TotalPrice,
                    PaidStatus = bookingRequest.PaidStatus,
                    ServiceDate = bookingRequest.ServiceDate,
                    ServiceType = bookingRequest.ServiceType,
                    BookedBy = bookingRequest.BookedBy,
                    ProblemDescription = bookingRequest.ProblemDescription
                };
                _dbContext.Bookings.Add(new_booking);
                _dbContext.SaveChanges();
                return Response.ApiResponse(true, "Booking Successful", new_booking);
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }

        internal object CancelBooking(int bookingId)
        {
            try
            {
                Booking booking = _dbContext.Bookings.Find(bookingId);
                if (booking != null)
                {
                    _dbContext.Bookings.Remove(booking);
                    _dbContext.SaveChanges();
                    return Response.ApiResponse(true, "Booking Canceled", booking);
                }
                else
                {
                    return Response.ApiResponse(false, "Booking not found", null);
                }
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }

        internal object UpdateBooking(int bookingId, BookingRequest newDetails)
        {
            try
            {
                Booking old_booking = _dbContext.Bookings.Find(bookingId);
                if (old_booking != null)
                {
                    old_booking.CompletedStatus = newDetails.CompletedStatus;
                    old_booking.Discount = newDetails.Discount;
                    old_booking.TotalPrice = newDetails.TotalPrice;
                    old_booking.PaidStatus = newDetails.PaidStatus;
                    old_booking.ServiceDate = newDetails.ServiceDate;
                    old_booking.ServiceType = newDetails.ServiceType;
                    old_booking.ProblemDescription = newDetails.ProblemDescription;
                    _dbContext.Entry(old_booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return Response.ApiResponse(true, "Booking updated successfully.", old_booking);
                }
                else
                {
                    return Response.ApiResponse(false, "No bookings found", null);
                }
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}
