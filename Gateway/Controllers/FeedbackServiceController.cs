using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeedbackService;
using FeedbackService.Models;

namespace Gateway.Controllers
{
    public class FeedbackServiceController : ApiController
    {
        // GET api/feedbackservice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/feedbackservice/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/feedbackservice
        public void Post([FromBody]string value)
        {
        }

        // DELETE api/feedbackservice/5
        public void Delete(int id)
        {
        }
    }
}
