using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillService.Models;

namespace BillService.Controllers
{
    public class BillController : ApiController
    {
        // GET api/bill
        [HttpGet]
        public IEnumerable<BillViewModel> GetBillsByUserId(int userId)
        {
            return null; //tmp !
        }

        // GET api/bill/5
        [HttpGet]
        public BillViewModel GetBillByDate(int userId, DateTime dt)
        {
            return new BillViewModel(); //tmp!
        }

        // POST api/bill
        public void Post([FromBody]BillViewModel billVm)
        {

        }

        // PUT api/bill/5
        [HttpPut]
        public void Put(int id, [FromBody]BillViewModel billVm)
        {

        }

        // DELETE api/bill/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
