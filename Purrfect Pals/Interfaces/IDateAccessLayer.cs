
using Purrfect_Pals.Models;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace Purrfect_Pals.Interfaces{

    public interface IDateAccessLayer{

        //should take in all the parts and add to user database, creates the bio
        //to hookup the Id's together

        //void AddUserBio(PetBio userBio);

        void AddUser(LoginInfo userInfo);
        
        //should search for the Id passed in and delete it from both databases
        //uses the petname to double check that it is the right person.

        void RemoveUser(int Id, string PetName);


        //Where you add the bio, also works as an edit
        //pretty simple, it should be able to go and edit the correct user's bio

        void EditBio(PetBio bio);

        //finds the bio and user for editing and deleting purposes

        public PetBio GetBio(int? id);

        public LoginInfo GetUser(int? id);

        public LoginInfo getUser(string username);

        IEnumerable<LoginInfo> GetUsers();

        bool LoginCheck(string username, string password);

    }

}
