using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using BillService.Models;

namespace Gateway.Services
{
    public class BillSrvc
    {
        private HttpClient _apiClient = new HttpClient();

        public IEnumerable<BillViewModel> GetBillsByUserId(int userId)
        {
            var data = Convert.ToString(_apiClient.GetStringAsync("api/bill/" + String.Format("{0}", userId)));
            var bills = JsonConvert.DeserializeObject<List<BillViewModel>>(data);
                
            return bills;
        }
        
        public BillViewModel GetBillByDate(int userId, DateTime dt)
        {
            var data = Convert.ToString(_apiClient.GetStringAsync("api/bill/" + String.Format("{0}", userId) + String.Format("{0}", dt)));
            var bill = JsonConvert.DeserializeObject<BillViewModel>(data);

            return bill;
        }

        public void RemoveBill(int id)
        {
            _apiClient.DeleteAsync("api/bill/" + String.Format("{0}", id));
        }
    }
}