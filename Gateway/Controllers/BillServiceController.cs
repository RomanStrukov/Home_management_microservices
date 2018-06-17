using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillService;
using BillService.Models;

namespace Gateway.Controllers
{
    public class BillServiceController : ApiController
    {
        // GET api/billservice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/billservice/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/billservice
        public void Post([FromBody]string value)
        {
        }

        // PUT api/billservice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/billservice/5
        public void Delete(int id)
        {
        }
    }
}
