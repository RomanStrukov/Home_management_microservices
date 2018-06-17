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
        [HttpGet]        
        public IEnumerable<string> GetBills()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/billservice/5
        [HttpGet]
        public string GetBillById(int id)
        {
            return "value";
        }

        // POST api/billservice
        [HttpPost]
        public void SaveNewBill([FromBody]string value)
        {
        }

        // PUT api/billservice/5
        [HttpPut]
        public void UpdateBill(int id, [FromBody]string value)
        {
        }

        // DELETE api/billservice/5
        [HttpDelete]
        public void RemoveBill(int id)
        {
        }
    }
}
