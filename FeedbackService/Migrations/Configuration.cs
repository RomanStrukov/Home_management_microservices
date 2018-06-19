namespace FeedbackService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FeedbackService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FeedbackService.Models.FeedbackDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FeedbackService.Models.FeedbackDBContext context)
        {
            context.feedbacks.AddOrUpdate(x => x.Id,
        new Feedback() { Id = 1, Content = "Too expensive bills!!", UserId = 1 },
        new Feedback() { Id = 2, Content = "Life is boring.", UserId = 1 },
        new Feedback() { Id = 3, Content = "There's no hot water!", UserId = 1 },
        new Feedback() { Id = 4, Content = "Germany lost.", UserId = 2 },
        new Feedback() { Id = 5, Content = "I want to Thailand...", UserId = 3 }
        ); 
        }
    }
}
