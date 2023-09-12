namespace SunflowersBookingSystem.Web.Models
{
    using SunflowersBookingSystem.Services.Models.Users;

    public class UpdateProfileViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public IFormFile? ProfilePicture { get; set; }

        public UpdateProfileDto ConvertToDto() =>
            new UpdateProfileDto()
            {
                Id = Id,
                Email = Email,
                FirstName = FirstName,
                SecondName = SecondName,
                Phone = Phone,
                Country = Country,
                ProfilePicture = ProfilePicture == null ? Constants.DefaultProfilePicture : ProfilePicture.FileName
            };
    }
}
