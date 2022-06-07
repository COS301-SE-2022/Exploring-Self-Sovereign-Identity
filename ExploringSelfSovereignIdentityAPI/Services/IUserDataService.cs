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

        //! Get Function
        /*
            To get string values for User Data service

        */
        Task<string> Get();

        //! Add Function
        /*
            To add User Data Models 

        */
        Task<UserDataModel> Add(UserDataModel e);
    }
}
