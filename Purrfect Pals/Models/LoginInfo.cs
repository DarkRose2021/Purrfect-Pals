
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using System.ComponentModel.DataAnnotations;

namespace Purrfect_Pals.Models{

    //Login Information

    public class LoginInfo{

        public int Id { get; set; }

        [MaxLength(60)]

        public string Username { get; set; }

        public string Password { get; set; }

        public LoginInfo(string username, string password){

            this.Username = username;

            this.Password = password;
        
        }

    }

}
