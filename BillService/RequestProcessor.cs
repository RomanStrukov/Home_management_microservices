using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillService;
using BillService.Models;
using BillService.Infrastructure;
using CounterService.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace BillService
{
    public class RequestProcessor
    {
        private SQLRepository _repo;
        private HttpClient _apiClient;

        public RequestProcessor()
        {
            _repo = new SQLRepository();            
            _apiClient = new HttpClient();
        }

        public IEnumerable<BillViewModel> GetBillsByUserId(int userId)
        {
            return _repo.GetBillsByUserId(userId);
        }

        public BillViewModel GetBillByDate(int userId, DateTime dt)
        {
            List<CounterViewModel> countersVm = new List<CounterViewModel>();
            Bill b = new Bill();

            b.Id = new Random().Next(1, 100);
            b.Price = CalculatePrice(userId, dt, out countersVm);
            b.Date = dt;
            b.Paid = false;
            b.UserId = userId;
            foreach (var cntVm in countersVm)
            {
                b.CounterNames.Add(cntVm.Name);
            }
            return _repo.ModelBinder.EntityToViewModel(b);
        }

        public bool Post(BillViewModel billVm)
        {
            Bill b = _repo.ModelBinder.ViewModelToEntity(billVm);

            _repo.Add(b);
            _repo.SaveChanges();

            return true;
        }

        public void Put(int id, BillViewModel billVm)
        {

        }

        public BillViewModel Delete(int id, out HttpStatusCode httpStatusCode)
        {
            try
            {                
                return _repo.Remove(id, out httpStatusCode);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }            
        }

        private int CalculatePrice(int userId, DateTime dt, out List<CounterViewModel> countersVm)
        {
            int finalPrice = 0;

            var data = Convert.ToString(_apiClient.GetStringAsync("api/counter/" + String.Format("{0}", userId)));
            countersVm = JsonConvert.DeserializeObject<List<CounterViewModel>>(data);
            List<Counter> counters = new List<Counter>();

            foreach (CounterViewModel counterVm in countersVm)
            {
                if (counterVm.Date == dt)
                    finalPrice += counterVm.Val;
            }

            Tariff trf = _repo.GetTariffByUserId(userId);

            finalPrice *= trf.Coefficient;

            return finalPrice;
        }


    }
}