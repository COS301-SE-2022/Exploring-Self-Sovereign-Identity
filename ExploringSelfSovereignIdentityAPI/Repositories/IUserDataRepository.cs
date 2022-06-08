using ExploringSelfSovereignIdentityAPI.Models.Entity; 
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

//! UserDataRepository 
/*
    Created User Data Repository for User Database
    @author Rebecca Pillay
 
*/
namespace ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository
{
    public interface IUserDataRepository
    {
        //! GetUserData Function
        /*
           To get user data for table:

           Name
           Surname
           Email
           Number

        */
        Task<UserDataModel> GetUserData (UserDataModel e);

        //! Add Function
        /*
           To add user data to table
        */
        Task<UserDataModel> Add(UserDataModel e);

        //! Get Function
        /*
           To get string values 
        */
        Task<string> Get();

        //! DeleteUserData Function
        /*
           To delete user data attributes 
        */

        Task<UserDataModel> UpdateUserData(UserDataModel e);
    }
}
