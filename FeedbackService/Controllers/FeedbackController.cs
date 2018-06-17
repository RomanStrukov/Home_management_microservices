using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FeedbackService.Models;

namespace FeedbackService.Controllers
{
    public class FeedbackController : ApiController
    {
        private RequestProcessor _requestProcessor = new RequestProcessor();

        // GET api/Feedback
        public IEnumerable<FeedbackViewModel> GetFeedbackViewModels()
        {
            return _requestProcessor.Get();
        }

        // GET api/Feedback/5
        public FeedbackViewModel GetFeedbackViewModel(int id)
        {
            try
            {
                return _requestProcessor.Get(id);
            }
            catch (HttpResponseException ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                
            }           
        }

        // POST api/Feedback
        public HttpResponseMessage PostFeedbackViewModel(FeedbackViewModel feedbackviewmodel)
        {
            if (!ModelState.IsValid || !_requestProcessor.Post(feedbackviewmodel))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);          
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, feedbackviewmodel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = feedbackviewmodel.Id }));
                return response;   
            }
        }

        // DELETE api/Feedback/5
        public HttpResponseMessage DeleteFeedbackViewModel(int id)
        {
            try
            {
                HttpStatusCode httpStatusCode;
                FeedbackViewModel feedbackviewmodel = _requestProcessor.Delete(id, out httpStatusCode);
                return Request.CreateResponse(HttpStatusCode.OK, feedbackviewmodel);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _requestProcessor.DisposeDB();
            base.Dispose(disposing);
        }
    }
}