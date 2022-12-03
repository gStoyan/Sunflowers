namespace SunflowersBookingSystem.Services.Users.Interfaces
{
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Models.Users;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequestDto model);
        IEnumerable<User> GetAllUsers();
        User GetById(int id);
        void Register(RegisterRequestDto model);
        //void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
