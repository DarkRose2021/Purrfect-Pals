
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Purrfect_Pals.Models;

namespace Purrfect_Pals.Data{

    public class AppDbContext : DbContext{

        public AppDbContext(DbContextOptions options) : base(options){

        }

        //the bottom 2 pieces should be the tables that get created.

        public DbSet<LoginInfo> UserInfo { get; set; }

        public DbSet<PetBio> Bio { get; set; }

    }

}
