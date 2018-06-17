using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackService.Models
{
    [Table ("tblFeedbacks")]
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
       
        // Foreign Key
        public int UserId { get; set; }
    }

    public class FeedbackDBContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<FeedbackViewModel> FeedbackViewModels { get; set; }
    }
}