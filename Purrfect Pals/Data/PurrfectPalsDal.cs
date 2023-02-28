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

        public void EditBio(PetBio bio){

            db.Bio.Update(bio);

            db.SaveChanges();

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

		public bool LoginCheck(string username, string password){
		
            if(username == null || password == null){

                return false;
            
            }

			IEnumerable<LoginInfo> isUsernameGood = GetUsers().Where(m => (!string.IsNullOrEmpty(m.Username) && m.Username.Contains(username))).ToList();
            
			IEnumerable<LoginInfo> isPasswordGood = GetUsers().Where(m => (!string.IsNullOrEmpty(m.Password) && m.Password.Contains(password))).ToList();

            if(isUsernameGood.Count() > 0 && isPasswordGood.Count() > 0){

                return true;
            
            }

            return false;

		}

		IEnumerable<LoginInfo> GetUsers(){

            return db.UserInfo.ToList();

		}

		IEnumerable<LoginInfo> IDateAccessLayer.GetUsers(){

			throw new NotImplementedException();

		}

		public LoginInfo getUser(string username){

			return db.UserInfo.Where(m => m.Username == username).FirstOrDefault();

		}

        public int getUserID(string username, string password){

            LoginInfo userholder = new LoginInfo();

            userholder = GetUsers().Where(m => (m.Username == username) && m.Password == password).First();

            return userholder.Id;

        }

    }

}
