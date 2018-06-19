using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillService.Models;

namespace BillService.Controllers
{
    public class BillController : ApiController
    {
        private RequestProcessor _rp = new RequestProcessor();

        // GET api/bill
        [HttpGet]
        public IEnumerable<BillViewModel> GetBillsByUserId(int userId)
        {
            return _rp.GetBillsByUserId(userId);
        }

        // GET api/bill/5
        [HttpGet]
        public BillViewModel GetBillByDate(int userId, DateTime dt)
        {
            return _rp.GetBillByDate(userId, dt);
        }

        // POST api/bill
        public HttpResponseMessage Post([FromBody]BillViewModel billVm)
        {
            if (!ModelState.IsValid || !_rp.Post(billVm))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, billVm);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = billVm.Id }));
                return response;
            }
        }

        // PUT api/bill/5
        [HttpPut]
        public void Put(int id, [FromBody]BillViewModel billVm)
        {

        }

        // DELETE api/bill/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                HttpStatusCode httpStatusCode;
                BillViewModel billviewmodel = _rp.Delete(id, out httpStatusCode);
                return Request.CreateResponse(HttpStatusCode.OK, billviewmodel);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
