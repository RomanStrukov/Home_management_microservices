using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CounterService.Models
{
    public class CounterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Val { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}