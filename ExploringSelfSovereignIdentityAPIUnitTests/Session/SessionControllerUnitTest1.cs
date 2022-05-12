using ExploringSelfSovereignIdentityAPI.Commands.SessionCommand;
using ExploringSelfSovereignIdentityAPI.Controllers.Session;
using ExploringSelfSovereignIdentityAPI.Models.Default;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExploringSelfSovereignIdentityAPIUnitTests.Session
{
    public class SessionControllerUnitTest1
    {
        [Fact]
        public async Task SessionControllerTest()
        {
            /*var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<GetDefaultSessionCommand>(), default(CancellationToken)));


            var command = new GetDefaultSessionCommand("654321");

            var controller = new SessionController(mockMediator.Object);

            var result = await controller.validateOTP(command);
            Assert.NotNull(result);
            Assert.Equal("Default Identity", result.IdentityName);*/
                
        }
    }
}
