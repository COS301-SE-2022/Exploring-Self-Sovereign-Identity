using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository;
using System.Threading.Tasks;
using Xunit;

namespace ExploringSelfSovereignIdentityAPIUnitTests
{
    public class SessionRepositoryUnitTest
    {

        /*public SessionRepository _sessionRepository;

        public SessionRepositoryUnitTest()
        {
            _sessionRepository = new SessionRepository();
        }

        [Fact]
        public async void Get_ValidtSession()
        {
            var defaultSessionModel = await _sessionRepository.GetMockSession(new DefaultSessionModel());

            Assert.Equal(11111, defaultSessionModel.SessionId);
            Assert.Equal("654321", defaultSessionModel.otp);
        }

        [Fact]
        public async void Get_ValidOtpResponse()
        {
            var otpResponse = await _sessionRepository.GetOtpResponse(new OtpResponse());

            Assert.Equal("654321", otpResponse.otp);
        }*/
    }
}