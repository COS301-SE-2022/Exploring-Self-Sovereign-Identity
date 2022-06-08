using System;

//! userDataModel Class 
/*
    Declared userDataModel class
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    //! Class for the User Data table 
    /*
        Id - Id associated with User data model attributes
        Hash - Unique hash associated with each user's biometric data 
        Profile_version - User profile version shown on application 

    */
    public class UserDataModel
    {
        public Guid Id { get; set; }
        public string Hash { get; set; }

        public int Profile_version { get; set; }



        /*
            Look into using the DBContext on the repository to CRUD user data
            Implement endpoints to CRUD user data
         */
        public UserDataModel()
        {

        }

        public UserDataModel(Guid Id, string Hash, int Profile_version)
        {
            this.Id = Id;
            this.Hash = Hash;
            this.Profile_version = Profile_version;

       
        }

        public void AddAttribute(string attribute, bool isRequired)
        {
            /*for(int i = 0; i < attribute.Length; i++)
            {
                attribute.Add(new Tuple<string, bool>(attribute, isRequired)); 

            }*/


        }

        public void DeleteAttribute(string attribute)
        {

        }

        public void UpdateAttribute(string attribute)
        {

        }

    }

   
}
