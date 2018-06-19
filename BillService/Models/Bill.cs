using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillService.Models
{
    [Table ("tblBills")]
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public List<string> CounterNames { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool Paid { get; set; }

        public int UserId { get; set; }
    }

    public class BillDBContext : DbContext
    {
        public DbSet<Bill> bills { get; set; }
        public DbSet<Tariff> tariffs { get; set; }
    }

}