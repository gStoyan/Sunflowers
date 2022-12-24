namespace SunflowersBookingSystem.Services.Users
{
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Models.Users;

    public interface IUserService
    {
        UserDto Authenticate(AuthenticateRequestDto model);
        IEnumerable<User> GetAllUsers();
        User GetById(int id);
        void Register(RegisterRequestDto model);
        Task<UserDto> UpdateAsync(UpdateProfileDto updatePorfileDto);
        void Delete(int id);
    }
}
