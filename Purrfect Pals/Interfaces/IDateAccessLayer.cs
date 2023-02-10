
using Purrfect_Pals.Models;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace Purrfect_Pals.Interfaces{

    public interface IDateAccessLayer{

        //should take in all the parts and add to user database, creates the bio
        //to hookup the Id's together

        void AddUser(LoginInfo userInfo);
        
        //should search for the Id passed in and delete it from both databases
        //uses the petname to double check that it is the right person.

        void RemoveUser(int Id, string PetName);

        //should take the Id of the user, go to that Id in the bio's table
        //and input the data into those fields

        void AddBio(int Id, PetBio bio);

        //pretty simple, it should be able to go and edit the correct user's bio

        void EditBio(int Id);

        //should filter through the bio-database searching for any and all with 
        //that pet name, it should probably return a redirect to a user's bio
        //with the user's Id as the variable to check / pass through?

        IEnumerable<PetBio> FindUser(string PetName);



    }

}
