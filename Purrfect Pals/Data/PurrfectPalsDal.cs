using Purrfect_Pals.Models;

using Purrfect_Pals.Interfaces;

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Purrfect_Pals.Data{

    public class PurrfectPalsDal : IDateAccessLayer{

        private AppDbContext db;

        public PurrfectPalsDal(AppDbContext indb){

            db = indb;
        
		}

        public PurrfectPalsDal(){

        }

        public void AddUserBio(PetBio userBio, int Id){

            PetBio targetBio = GetBio(Id);

            db.Bio.Add(targetBio);

            db.SaveChanges();

        }

        public void EditBio(int Id, PetBio bio){

            PetBio targetBio = GetBio(Id);

            db.Bio.Update(targetBio);

        }

        public PetBio GetBio(int? id){

            return db.Bio.Where(m => m.Id == id).FirstOrDefault();

        }

        public LoginInfo GetUser(int? id){

            return db.UserInfo.Where(m => m.Id == id).FirstOrDefault();

        }

        public void RemoveUser(int Id, string PetName){

            PetBio foundBio = GetBio(Id);

            LoginInfo user = GetUser(Id);

            db.UserInfo.Remove(user);

            db.Bio.Remove(foundBio);

            db.SaveChanges();
        
        }

        public void AddUser(LoginInfo userInfo){

            PetBio bio = new PetBio();//bull bio so the database id's match

            bio.Biography = "temp";

            bio.PetName = userInfo.PetName;

            bio.Likes = "temp";

            bio.Dislikes = "temp";

            bio.PetAge = 4;

            db.UserInfo.Add(userInfo);

            db.Bio.Add(bio);

            db.SaveChanges();

        }

    }

}
