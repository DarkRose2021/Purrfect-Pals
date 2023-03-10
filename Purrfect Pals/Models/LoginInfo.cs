
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purrfect_Pals.Models{

    //Login Information

    public class LoginInfo{

        [Key]

        public int Id { get; set; }

        [ForeignKey("Id")]

        public string Username { get; set; }

        [MinLength(6), MaxLength(27)]

        public string Password { get; set; }

        public string PetName { get; set; }

        public LoginInfo() { }

        public LoginInfo(string username, string password, string petName){

            this.Username = username;

            this.Password = password;
        
            this.PetName = petName;
        
        }

        public override string ToString(){

            return $"Welcome {Username}";

        }

    }

}
