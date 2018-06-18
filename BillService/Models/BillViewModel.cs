using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillService.Models
{
    public class BillViewModel
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        IEnumerable<string> CounterNames { get; set; }
        int Price { get; set; }
        bool Status { get; set; }
        int UserId { get; set; }
        IEnumerable<int> CounterIds { get; set; }
    }
}