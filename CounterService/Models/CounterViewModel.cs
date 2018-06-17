using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CounterService.Models
{
    public class CounterViewModel
    {
        int Id { get; set; }
        int val { get; set; }

        int UserId { get; set; }
    }
}