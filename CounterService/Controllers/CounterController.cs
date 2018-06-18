using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CounterService.Models;

namespace CounterService.Controllers
{
    public class CounterController : ApiController
    {
        private RequestProcessor _requestProcessor = new RequestProcessor();

        // GET api/counter
        [HttpGet]
        public IEnumerable<CounterViewModel> GetCountersByUserId(int userId)
        {
            return _requestProcessor.GetCountersByUserId(userId);
        }

        // POST api/counter
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CounterViewModel cntVm)
        {
            if (!ModelState.IsValid || !_requestProcessor.Post(cntVm))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cntVm);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cntVm.Id }));
                return response;
            }
        }

        // PUT api/counter/5
        [HttpPut]
        public void Put(int id, [FromBody]CounterViewModel cntVm)
        {

        }

        // DELETE api/counter/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                HttpStatusCode httpStatusCode;
                CounterViewModel feedbackviewmodel = _requestProcessor.Delete(id, out httpStatusCode);
                return Request.CreateResponse(HttpStatusCode.OK, feedbackviewmodel);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
