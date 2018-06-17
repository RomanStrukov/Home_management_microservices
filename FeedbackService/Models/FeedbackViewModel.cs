using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackService.Models
{
    public class FeedbackViewModel
    {
         public int Id { get; set; }
         public string Content { get; set; }
         public User Author {get; set;}
    }

}