namespace SunflowersBookingSystem.Services.Mapping
{
    using AutoMapper;
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Models.Users;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());

            CreateMap<RegisterRequestDto, User>();

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
