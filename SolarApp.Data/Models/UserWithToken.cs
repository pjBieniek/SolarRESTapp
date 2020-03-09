namespace SolarApp.Data.Models
{
    public class UserWithToken : UserDTO
    {
        public string Token { get; set; }

        public UserWithToken(UserDTO user)
        {
            this.UserId = user.UserId;
            this.UserFullName = user.UserFullName;
            this.UserEmail = user.UserEmail;
        }
    }
}
