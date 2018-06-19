using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillService.Models
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<string> CounterNames { get; set; }
        public int Price { get; set; }
        public bool Paid { get; set; }
        public int UserId { get; set; }
    }
}