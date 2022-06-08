﻿using ExploringSelfSovereignIdentityAPI.Models.Entity; 
using ExploringSelfSovereignIdentityAPI.Queries.ConnectEndpoint;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ExploringSelfSovereignIdentityAPI.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : Controller
    {
        private readonly IMediator mediator;

        public UserDataController(IMediator med)
        {
            mediator = med;
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

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
