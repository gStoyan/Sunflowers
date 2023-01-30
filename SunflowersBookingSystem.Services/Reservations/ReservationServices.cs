namespace SunflowersBookingSystem.Services.Reservations
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using SunflowersBookingSystem.Data;
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Extensions;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Models.Reservations;

    public class ReservationServices : IReservationServices
    {

        private SunflowersDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ReservationServices(SunflowersDbContext context, IMapper mapper, ILogger<ReservationServices> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public void Create(ReservationDto reservationDto)
        {
            var rooms = _context.Rooms.Include(r => r.Reservations).ToList();
            var room = rooms
                .Where(r => !r.Reservations.Any(res => res.StartDate.IsBetween(reservationDto.StartDate, reservationDto.EndDate) &&
                res.EndDate.IsBetween(reservationDto.StartDate, reservationDto.EndDate))).FirstOrDefault();


            if (room == null)
            {
                _logger.LogCritical(ServicesLogEvents.UsersOperation, $"No available rooms found for {reservationDto.StartDate}");
                throw new ArgumentNullException("No Rooms Found");
            }

            var reservation = new Reservation()
            {
                ArriveTime = reservationDto.ArriveTime,
                Comment = reservationDto.Comment,
                EndDate = reservationDto.EndDate,
                StartDate = reservationDto.StartDate,
                UserId = reservationDto.UserId
            };
            reservation.Rooms.Add(room);
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            _logger.LogInformation(ServicesLogEvents.UsersOperation,
                $"Reservation made on {reservationDto.StartDate} in room {room.Id}.");
        }

        public void Delete(int id)
        {
            var reservations = _context.Reservations.Include(r => r.Rooms).Include(r => r.User);
            var reservation = reservations.FirstOrDefault(r => r.Id == id);

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }

        public IEnumerable<ReservationDto> GetAll()
        {
            var reservations = _context.Reservations.ToList();
            var reservationsDto = _mapper.Map<List<Reservation>, List<ReservationDto>>(reservations);
            return reservationsDto;
        }

        public ReservationDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
