using ExploringSelfSovereignIdentityAPI.Models.Entity; 
using ExploringSelfSovereignIdentityAPI.Queries.ConnectEndpoint;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Services;
using ExploringSelfSovereignIdentityAPI.Services.UserDataService;

namespace ExploringSelfSovereignIdentityAPI.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserDataService _UserDataService; 

        public UserDataController(IMediator med, UserdataService userDataService)
        {
            mediator = med;
            _UserDataService = userDataService;

        }



        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //Login Endpoint 
        [HttpGet("{id, hash}")]
        public IActionResult Get(UserDataModel Id, UserDataModel hash)
        {

            var user = _UserDataService.GetUser(Id, hash);
            return (IActionResult)user; 

        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // Register Endpoint 
        [HttpPut("{id, hash}")]
        public void Put(UserDataModel Id)
        {
            _UserDataService.Add(Id);

        }

        /* DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }*/
    }
}
