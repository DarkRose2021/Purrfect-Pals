
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purrfect_Pals.Models{

    //Biography section for users (rough draft)

    public class PetBio{

        [Key]

        public int Id { get; set; }

		[MaxLength(30)]

        public string PetName { get; set; }

        [MaxLength(360)]

        public string Biography { get; set; }

        public int PetAge { get; set; }

        public string? Likes { get; set; }

        public string? Dislikes { get; set; }

        public string? Image { get; set; }

        public PetBio() { }

        public PetBio(string name, int age, string likes, string dislikes, string image){

            this.PetName = name;

            this.PetAge= age;

            this.Likes= likes;

            this.Dislikes= dislikes;

            this.Image = image;
        
        }

    }

}
