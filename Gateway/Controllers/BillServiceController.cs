using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gateway.Services;
using BillService;
using BillService.Models;

namespace Gateway.Controllers
{
    public class BillServiceController : ApiController
    {
        private BillSrvc _bill = new BillSrvc();

        // GET api/bill
        [HttpGet]
        public IEnumerable<BillViewModel> GetBillsByUserId(int userId)
        {
            return _bill.GetBillsByUserId(userId);
        }

        // GET api/bill/5
        [HttpGet]
        public BillViewModel GetBillByDate(int userId, DateTime dt)
        {
            return _bill.GetBillByDate(userId, dt);
        }

        // DELETE api/bill/5
        [HttpDelete]
        public void RemoveBill(int id)
        {
            _bill.RemoveBill(id);
        }
    }
}
