namespace SunflowersBookingSystem.Services.Users
{
    using AutoMapper;
    using BCrypt.Net;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using SunflowersBookingSystem.Data;
    using SunflowersBookingSystem.Data.Models;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Models.Users;
    using SunflowersBookingSystem.Services.Users.Interfaces;

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

        public UserDto Authenticate(AuthenticateRequestDto model)
        {
            var user = _context.Users.Include(u => u.Reservations).SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
                throw new Exception($"{model.Email} Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<UserDto>(user);
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
            var users = _context.Users.Include(u => u.Reservations);
            var user = users.FirstOrDefault(x => x.Id == id);

            return user;
        }

        public void Register(RegisterRequestDto model)
        {
            _logger.LogInformation(ServicesLogEvents.UsersOperation, $"{model.FirstName} is trying to register.");
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new Exception("Username '" + model.Email + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCrypt.HashPassword(model.PasswordHash);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public async Task<UserDto> UpdateAsync(UpdateProfileDto updatePorfileDto)
        {
            var user = GetById(int.Parse(updatePorfileDto.Id));

            user.Email = updatePorfileDto.Email;
            user.ProfilePicture = updatePorfileDto.ProfilePicture;
            user.Country = updatePorfileDto.Country;
            user.Phone = updatePorfileDto.Phone;
            user.FirstName = updatePorfileDto.FirstName;
            user.SecondName = updatePorfileDto.SecondName;

            await _context.SaveChangesAsync();

            var response = _mapper.Map<UserDto>(user);

            return response;
        }
    }
}
