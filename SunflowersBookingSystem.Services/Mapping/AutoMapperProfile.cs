namespace SunflowersBookingSystem.Services.Mapping
{
    using AutoMapper;
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Models.Reservations;
    using SunflowersBookingSystem.Services.Models.Users;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.Room, opt => opt.Ignore());



            CreateMap<RegisterRequestDto, User>()
                .ForMember(dest => dest.Reservations, opt => opt.Ignore())
                .ForMember(dest => dest.ProfilePicture, opt => opt.Ignore());

            //CreateMap<UpdateRequest, User>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest, prop) =>
            //        {
            //        // ignore null & empty string properties
            //        if (prop == null) return false;
            //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //            return true;
            //        }
            //    ));
        }
    }
}
