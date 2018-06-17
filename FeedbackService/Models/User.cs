using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackService.Models
{
    [Table("tblUsers")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name contains letters only!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Middle name contains letters only!")]
        public string MiddleName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Last name contains letters only!")]
        public string LastName { get; set; }
    }

    public class UserDBContext : DbContext
   {
      public DbSet<User> Users { get; set; }
   }
}