﻿namespace SunflowersBookingSystem.Services.Users.Interfaces
{
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Models;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequestDto model);
        IEnumerable<User> GetAllUsers();
        User GetById(int id);
        void Register(RegisterRequest model);
        //void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}