using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CounterService;
using CounterService.Models;
using Gateway.Services;

namespace Gateway.Controllers
{
    public class CounterServiceController : ApiController
    {
        private readonly CounterSrvc _counter = new CounterSrvc();

        // GET api/counterservice/4
        [HttpGet]
        public IEnumerable<CounterViewModel> GetCountersByUserId(int userId)
        {
            return _counter.GetCountersByUserId(userId);
        }

        // POST api/counterservice
        [HttpPost]
        public void AddCounter([FromBody]CounterViewModel cntVm)
        {
            _counter.AddCounter(cntVm);
        }

        // PUT api/counterservice/5
        [HttpPut]
        public void UpdateCounterIndicators(int id, [FromBody]CounterViewModel cntVm)
        {
            _counter.UpdateCounterIndicators(id, cntVm);
        }

        // DELETE api/counterservice/5
        [HttpDelete]
        public void RemoveCounter(int id)
        {
            _counter.RemoveCounter(id);
        }
    }
}
