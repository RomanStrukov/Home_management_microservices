using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeedbackService.Models;
using Gateway.Services;

namespace Gateway.Controllers
{
    public class FeedbackServiceController : ApiController
    {
        private readonly FeedbackSrvc _feedback = new FeedbackSrvc();

        // GET api/feedbackservice
        [HttpGet]
        public IEnumerable<FeedbackViewModel> GetFeedbacksByUserId(int userId)
        {
            return _feedback.GetFeedbacksByUserId(userId);
        }

        //// GET api/feedbackservice/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/feedbackservice
        [HttpPost]
        public void SaveNewFeedback([FromBody]FeedbackViewModel fbVm)
        {
            _feedback.SaveNewFeedback(fbVm);
        }

        // DELETE api/feedbackservice/5
        [HttpDelete]
        public void RemoveFeedback(int id)
        {
            _feedback.RemoveFeedback(id);
        }
    }
}
