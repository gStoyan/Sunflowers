namespace SunflowersBookingSystem.Services.Users.Interfaces
{
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Models;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequest model);
        //void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
