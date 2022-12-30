namespace SunflowersBookingSystem.Services.Reservations
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using SunflowersBookingSystem.Data;
    using SunflowersBookingSystem.Data.Models;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
