namespace BillService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BillService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BillService.Models.BillDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BillService.Models.BillDBContext context)
        {
            context.tariffs.AddOrUpdate(x => x.Id,
        new Tariff() { Id = 1, Name = "Light", Coefficient = 4, UserId = 1 },
        new Tariff() { Id = 2, Name = "Medium", Coefficient = 3, UserId = 2 },
        new Tariff() { Id = 3, Name = "Hard", Coefficient = 2, UserId = 3 }
        ); 
          
        }
    }
}
