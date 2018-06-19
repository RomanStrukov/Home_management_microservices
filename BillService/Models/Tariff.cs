using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillService.Models
{
    [Table ("tblTariffs")]
    public class Tariff
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Coefficient { get; set; }
        public int UserId { get; set; }
    }
}