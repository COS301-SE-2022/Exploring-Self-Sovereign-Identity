using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository
{
    public class SessionRepository : ISessionRepository
    {
        private MongoClient client;
        private IMongoDatabase database;

        public SessionRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("BlockChain");
        }

        public async Task<DefaultIdentityModel> GetMockDefaultIdentity(DefaultIdentityModel e)
        {
            e.addAttribute("Name", true);
            e.addAttribute("Surame", false);
            e.addAttribute("Email", true);
            e.addAttribute("Number", false);

            return await Task.FromResult(e);
        }

        public async Task<DefaultSessionModel> GetMockSession(DefaultSessionModel e)
        {
            e.SessionId = 11111;
            e.otp = "654321";
            e._identity = await GetMockDefaultIdentity(new DefaultIdentityModel());

            return await Task.FromResult(e);
        }
        public async Task<DefaultIdentityResponse> confirmIdentity(LinkedList<string> fields)
        {
            DefaultIdentityResponse response = new DefaultIdentityResponse();

            foreach(string field in fields)
            {
                if(field == "name")
                {
                    response.identity.Add("name", "Jacob");
                }
                else if(field == "surname")
                {
                    response.identity.Add("surname", "Smith");
                }
                else if (field == "email")
                {
                    response.identity.Add("email", "jsp@gmail.com");
                }
                else if(field == "address")
                {
                    response.identity.Add("address", "14 Marais, Hatfield, Pretoria");
                }
            }

            response.token = "fwerwehvuvgvyvdwewmp5fwfewbiybjjhgyvbue";

            return await Task.FromResult(response);
        }

        public async Task<OtpResponse> GetOtpResponse(OtpResponse e)
        {
            //throw new NotImplementedException();
            //OtpResponse response = new OtpResponse();
            //response.otp = "123456";

            e.otp = "654321";

            //return await Task.FromResult(response);
            return await Task.FromResult(e);
        }
    }
}
