namespace SunflowersBookingSystem.Services.Users
{
    using AutoMapper;
    using SunflowersBookingSystem.Data;
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Models;
    using SunflowersBookingSystem.Services.Users.Interfaces;
    using BCrypt.Net;

    public class UserService : IUserService
    {
        private SunflowersDbContext context;
        private IJwtUtils jwtUtils;
        private readonly IMapper mapper;

        public UserService(SunflowersDbContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            this.context = context;
            this.jwtUtils = jwtUtils;
            this.mapper = mapper;   
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = context.Users.SingleOrDefault(x => x.FirstName == model.FirstName);

            // validate
            if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
                throw new Exception("Username or password is incorrect");

            // authentication successful
            var response = mapper.Map<AuthenticateResponse>(user);
            response.Token = jwtUtils.GenerateToken(user);
            return response;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterRequest model)
        {
            // validate
            if (context.Users.Any(x => x.FirstName == model.FirstName))
                throw new Exception("Username '" + model.FirstName + "' is already taken");
            // map model to new user object
            var user = mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCrypt.HashPassword(model.PasswordHash);

            // save user
            context.Users.Add(user);
            context.SaveChanges();
        }

        //public void Update(int id, UpdateRequest model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
