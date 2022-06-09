using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Threading.Tasks;

//! UserDataService
/*
    Created User Data Service for User Database
    @author Rebecca Pillay
 
*/

namespace ExploringSelfSovereignIdentityAPI.Services.UserDataService
{
    
    public interface IUserDataService
    {

        Task<UserDataModel> GetUser(UserDataModel e, UserDataModel f); 

        Task<UserDataModel> GetUserData(UserDataModel e); 

        //! Add Function
        /*
            To add User Data Models 

        */
        Task<UserDataModel> Add(UserDataModel e);
    }
}
