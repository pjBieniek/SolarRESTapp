using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Models
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
