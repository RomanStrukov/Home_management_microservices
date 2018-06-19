using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillService.Models;

namespace BillService
{
    public class ModelBinder
    {
        public Bill ViewModelToEntity(BillViewModel billVm)
        {
            Bill bill = new Bill();

            bill.Id = billVm.Id;
            bill.Date = billVm.Date;
            bill.Price = billVm.Price;
            bill.Paid = billVm.Paid;
            bill.CounterNames = billVm.CounterNames;
            bill.UserId = billVm.UserId;

            return bill;
        }

        public BillViewModel EntityToViewModel(Bill bill)
        {
            BillViewModel billVm = new BillViewModel();

            billVm.Id = bill.Id;
            billVm.Date = bill.Date;
            billVm.Price = bill.Price;
            billVm.Paid = bill.Paid;
            billVm.CounterNames = bill.CounterNames;
            billVm.UserId = bill.UserId;

            return billVm;
        }
    }
}