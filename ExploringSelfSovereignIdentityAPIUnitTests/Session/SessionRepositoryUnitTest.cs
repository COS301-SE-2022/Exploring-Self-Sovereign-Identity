using ExploringSelfSovereignIdentityAPI.Models.Default;
using ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository;
using System.Threading.Tasks;
using Xunit;

namespace ExploringSelfSovereignIdentityAPIUnitTests
{
    public class SessionRepositoryUnitTest
    {

        public SessionRepository _sessionRepository;

        public SessionRepositoryUnitTest()
        {
            _sessionRepository = new SessionRepository();
        }

        [Fact]
        public async void Get_ValidtSession()
        {
            DefaultSessionModel defaultSessionModel = await _sessionRepository.GetMockSession(new DefaultSessionModel());

            Assert.Equal(11111, defaultSessionModel.SessionId);

        }
    }
}