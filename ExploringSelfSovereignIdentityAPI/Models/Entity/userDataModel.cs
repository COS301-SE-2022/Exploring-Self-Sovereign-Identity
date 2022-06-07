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

        //public List<Tuple<string, bool>> Attributes { get; }

        //public List<Tuple<string, bool>> Credentials { get; } 

        //! UserDataModel function 
        /*
            Function to add User data 

        */
        public UserDataModel()
        {
            //Attributes = new List<Tuple<string, bool>>();
       
        }

        //! AddAttribute function 
        /*
            Function to add attributes to User Data table 

        */
        public void AddAttribute(string attribute, bool isRequired)
        {
            /*for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Item1 == attribute)
                    throw new ArgumentException();
            }*/

            //attributes.Add(new Tuple<string, bool>(attribute, isRequired));
        }

    }

   
}
