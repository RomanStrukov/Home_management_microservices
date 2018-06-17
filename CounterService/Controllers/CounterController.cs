using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CounterService.Models;

namespace CounterService.Controllers
{
    public class CounterController : ApiController
    {
        // GET api/counter
        [HttpGet]
        public IEnumerable<string> GetCountersByUserId(int userId)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/counter
        [HttpPost]
        public void Post([FromBody]CounterViewModel cntVm)
        {

        }

        // PUT api/counter/5
        [HttpPut]
        public void Put(int id, [FromBody]CounterViewModel cntVm)
        {

        }

        // DELETE api/counter/5
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
