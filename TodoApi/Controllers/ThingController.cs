using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{

    [Route("api/controller")]
    public class ThingController : Controller
    {
        private readonly ThingContext _thingContext;

        public ThingController(ThingContext context)
        {
            if (_thingContext.Things.Count() == 0)
            {
                _thingContext.Add(new Thing { Description = "This the new thing" });
                _thingContext.SaveChanges();
            }
        }

        // GET: api/Thing
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Thing/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Thing
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Thing/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
