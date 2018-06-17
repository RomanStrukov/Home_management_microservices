using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CounterService.Models;

namespace CounterService
{
    public class ModelBinder
    {
        public Counter ViewModelToEntity(CounterViewModel cntVm)
        {
            Counter cnt = new Counter();

            cnt.Id = cntVm.Id;
            cnt.val = cntVm.val;
            cnt.UserId = cntVm.UserId;

            return cnt;
        }

        public CounterViewModel EntityToViewModel(Counter cnt)
        {
            CounterViewModel cntVm = new CounterViewModel();

            cntVm.Id = cnt.Id;
            cntVm.val = cnt.val;
            cntVm.UserId = cnt.UserId;

            return cntVm;
        }
    }
}