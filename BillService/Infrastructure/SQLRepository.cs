using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using BillService.Models;

namespace BillService.Infrastructure
{
    public class SQLRepository : IRepository
    {        
        private BillDBContext _db;

        public ModelBinder ModelBinder { get; set; }

        public SQLRepository()
        {
            _db = new BillDBContext();
            ModelBinder = new ModelBinder();
        }

        public IEnumerable<BillViewModel> GetBillsByUserId (int userId)
        {
             List<Bill> bills = new List<Bill>();
            foreach (Bill b in _db.bills)
            {
                if (b.UserId == userId)
                    bills.Add(b);
            }

            List<BillViewModel> billViewModels = new List<BillViewModel>();
            foreach (var b in bills)
            {
                billViewModels.Add(ModelBinder.EntityToViewModel(b));
            }
            return billViewModels.AsEnumerable<BillViewModel>();
        }

        public Tariff GetTariffByUserId(int userId)
        {
            return _db.tariffs.First<Tariff>(tariff => tariff.UserId == userId);
        }

        public void Add(Bill b)
        {           
            _db.bills.Add(b);
            SaveChanges();
        }

        public BillViewModel Remove(int id, out HttpStatusCode httpStatusCode)
        {
            Bill b = _db.bills.Find(id);
            httpStatusCode = HttpStatusCode.OK;

            if (b == null)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                return null;
            }

            _db.bills.Remove(b);

            try
            {
                _db.SaveChanges();
                return ModelBinder.EntityToViewModel(b);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void DisposeDB()
        {
            _db.Dispose();
        }
    }
}