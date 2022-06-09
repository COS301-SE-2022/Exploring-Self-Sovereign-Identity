using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories; 
using Microsoft.AspNetCore.Http;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Services;
using ExploringSelfSovereignIdentityAPI.Services.UserDataService;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
namespace ExploringSelfSovereignIdentityAPI.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : Controller
    {
        private readonly IUserDataService _context;

        public UserDataController(IUserDataService context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult GetUser(UserDataModel Id)
        {

            var user = _context.GetUser(Id);
            return (IActionResult) user;

        }

        [HttpPost]
        [Route("register")]

        public IActionResult Add(UserDataModel hash)
        {
            var user = _context.Add(hash); 
            return (IActionResult) user;    
        }

        [HttpPost]
        [Route("update")]

        public IActionResult UpdateUserData(UserDataModel Id)
        {
            var user = _context.UpdateUserData(Id);
            return (IActionResult)user;
        }





        /*private readonly IMediator mediator;
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
