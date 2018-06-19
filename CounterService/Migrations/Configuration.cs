namespace CounterService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CounterService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CounterService.Models.CounterDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CounterService.Models.CounterDBContext context)
        {
            context.counters.AddOrUpdate(x => x.Id,
        new Counter() { Id = 1, Name = "Electricity", Val = 20, Date = new DateTime(2018, 06, 17), UserId = 1 },
        new Counter() { Id = 2, Name = "Water", Val = 16, Date = new DateTime(2018, 06, 18), UserId = 1 },
        new Counter() { Id = 3, Name = "Gas", Val = 30, Date = new DateTime(2018, 06, 19), UserId = 1 }
        );

            context.counters.AddOrUpdate(x => x.Id,
        new Counter() { Id = 5, Name = "Electricity", Val = 5, Date = new DateTime(2018, 05, 17), UserId = 2 },
        new Counter() { Id = 6, Name = "Water", Val = 14, Date = new DateTime(2018, 05, 18), UserId = 2 });

            context.counters.AddOrUpdate(x => x.Id,
        new Counter() { Id = 7, Name = "Gas", Val = 80, Date = new DateTime(2018, 05, 02), UserId = 3 });
        }
    }
}