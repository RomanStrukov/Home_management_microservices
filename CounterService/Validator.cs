using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CounterService.Models;

namespace CounterService
{
    public class Validator
    {
        public bool Valid(Counter cnt)
        {
            return cnt.val >= 0;
        }
    }
}