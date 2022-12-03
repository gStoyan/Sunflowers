namespace SunflowersBookingSystem.Services.Users
{
    using AutoMapper;
    using SunflowersBookingSystem.Data;
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Users.Interfaces;
    using Microsoft.Extensions.Logging;
    using BCrypt.Net;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    using SunflowersBookingSystem.Services.Models.Users;

    public class UserService : IUserService
    {
        private SunflowersDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserService(SunflowersDbContext context, IJwtUtils jwtUtils, IMapper mapper, ILogger<UserService> logger)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;   
            _logger = logger;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequestDto model)
        {
            var user = _context.Users.SingleOrDefault(x => x.FirstName == model.FirstName);

            // validate
            if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
                throw new Exception($"{model.FirstName} Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);

            return response;
        }

        public void Delete(int id)
        {

        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            users.AddRange(_context.Users.ToList());

            return users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x=>x.Id == id);

            return user;
        }

        public void Register(RegisterRequestDto model)
        {
            _logger.LogInformation(ServicesLogEvents.UsersOperation, $"{model.FirstName} is trying to register.");
            // validate
            if (_context.Users.Any(x => x.FirstName == model.FirstName))
                throw new Exception("Username '" + model.FirstName + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCrypt.HashPassword(model.PasswordHash);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        //public void Update(int id, UpdateRequest model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
