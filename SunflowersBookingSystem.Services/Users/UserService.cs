namespace SunflowersBookingSystem.Services.Users
{
    using AutoMapper;
    using SunflowersBookingSystem.Data;
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Models;
    using SunflowersBookingSystem.Services.Users.Interfaces;
    using Microsoft.Extensions.Logging;
    using BCrypt.Net;

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

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.FirstName == model.FirstName);

            // validate
            if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            {
                _logger.LogInformation(ServicesLogEvents.UsersOperation, $"{model.FirstName} authentication failed.");
                throw new Exception("Username or password is incorrect");
            }

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
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
