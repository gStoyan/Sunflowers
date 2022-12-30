namespace SunflowersBookingSystem.Services.Reservations
{
    using System.Collections.Generic;
    using SunflowersBookingSystem.Services.Models.Reservations;

    public interface IReservationServices
    {
        IEnumerable<ReservationDto> GetAll();

        ReservationDto GetById(int id);

        void Create(ReservationDto reservationDto);

        void Delete(int id);
    }
}
